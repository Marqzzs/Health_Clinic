using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Repositories;
using System;

namespace webapi.healthclinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">Os dados do novo usuário a serem cadastrados.</param>
        /// <returns>Um código de status 201 (Created) se o usuário foi cadastrado com sucesso.</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201); // Status 201: Recurso criado com sucesso
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser buscado.</param>
        /// <returns>Os dados do usuário encontrado ou um código de status 400 (Bad Request) se não encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario != null)
                {
                    return Ok(usuario); // Status 200: Requisição bem-sucedida
                }
                else
                {
                    return NotFound(); // Status 404: Recurso não encontrado
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }

        /// <summary>
        /// Obtém um usuário pelo email e senha.
        /// </summary>
        /// <param name="email">O email do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>Os dados do usuário encontrado ou um código de status 400 (Bad Request) se não encontrado.</returns>
        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                if (usuario != null)
                {
                    return Ok(usuario); // Status 200: Requisição bem-sucedida
                }
                else
                {
                    return NotFound(); // Status 404: Recurso não encontrado
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); // Status 400: Requisição inválida
            }
        }
    }
}
