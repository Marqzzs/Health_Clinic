using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace webapi.healthclinic.manha.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly HealthContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza um tipo de usuário no banco de dados.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser atualizado.</param>
        /// <param name="tipoUsuario">Os novos dados do tipo de usuário.</param>
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            // Busca o tipo de usuário pelo ID
            TipoUsuario tipoBuscado = ctx.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                // Atualiza os dados do tipo de usuário
                tipoBuscado.Titulo = tipoUsuario.Titulo;
            }

            // Atualiza o tipo de usuário no contexto e no banco de dados
            ctx.TipoUsuario.Update(tipoBuscado!);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser buscado.</param>
        /// <returns>O tipo de usuário encontrado.</returns>
        public TipoUsuario BuscarPorId(Guid id)
        {
            // Busca o tipo de usuário pelo ID e retorna-o
            return ctx.TipoUsuario!.FirstOrDefault(t => t.IdTipoUsuario == id)!;
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário no banco de dados.
        /// </summary>
        /// <param name="tipoUsuario">Os dados do novo tipo de usuário.</param>
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            // Gera um novo ID para o tipo de usuário
            tipoUsuario.IdTipoUsuario = Guid.NewGuid();

            // Adiciona o tipo de usuário ao contexto e salva no banco de dados
            ctx.TipoUsuario!.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Exclui um tipo de usuário do banco de dados pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do tipo de usuário a ser excluído.</param>
        public void Deletar(Guid id)
        {
            // Busca o tipo de usuário pelo ID
            TipoUsuario tipoBuscado = ctx.TipoUsuario.Find(id)!;

            // Remove o tipo de usuário do contexto e do banco de dados
            ctx.TipoUsuario.Remove(tipoBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuário cadastrados no banco de dados.
        /// </summary>
        /// <returns>Uma lista de tipos de usuário.</returns>
        public List<TipoUsuario> ListarTodos()
        {
            // Retorna uma lista com todos os tipos de usuário no banco de dados
            return ctx.TipoUsuario!.ToList();
        }
    }
}
