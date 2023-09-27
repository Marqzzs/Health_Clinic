using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Uteis;
using System;
using System.Linq;

namespace webapi.healthclinic.manha.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly HealthContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Busca um usuário pelo email e senha.
        /// </summary>
        /// <param name="email">O email do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>O usuário encontrado ou null se não encontrado.</returns>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                // Consulta o usuário no banco de dados
                Usuario usuarioBuscado = ctx.Usuario!.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Tipo = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipo,
                        Titulo = u.Tipo!.Titulo,
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    // Compara a senha fornecida com a senha armazenada no banco de dados
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser buscado.</param>
        /// <returns>O usuário encontrado ou null se não encontrado.</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                // Consulta o usuário no banco de dados pelo ID
                Usuario usuarioBuscado = ctx.Usuario!.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Tipo = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipo,
                        Titulo = u.Tipo!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }

                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo usuário no banco de dados.
        /// </summary>
        /// <param name="usuario">Os dados do novo usuário.</param>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                // Gera um novo ID para o usuário
                usuario.IdUsuario = Guid.NewGuid();

                // Criptografa a senha antes de armazená-la no banco de dados
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                // Adiciona o usuário ao contexto e salva no banco de dados
                ctx.Usuario!.Add(usuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
