using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;
using webapi.healthclinic.manha.ViewModel;
using System;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Realiza a autenticação de um usuário e gera um token JWT válido.
        /// </summary>
        /// <param name="usuario">Os dados de login do usuário.</param>
        /// <returns>Um objeto JSON contendo o token JWT.</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                // Busca o usuário com base no e-mail e senha fornecidos
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha incorretos");
                }

                // Define as claims (reivindicações) para o token JWT
                var claims = new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo!.Titulo!),
                };

                // Define a chave de segurança e as credenciais de assinatura
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("webapi-health-clinic-chave-autenticacao"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Cria o token JWT
                var meuToken = new JwtSecurityToken(
                    issuer: "webapi.healthclinic.manha",
                    audience: "webapi.healthclinic.manha",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds
                );

                // Retorna o token JWT como uma resposta
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
