using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ComentarioRepository : IComentario
    {
        private readonly HealthContext ctx;

        public ComentarioRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Adiciona um novo comentário ao contexto do banco de dados.
        /// </summary>
        /// <param name="comentario">O objeto Comentario a ser adicionado.</param>
        public void Comentar(Comentario comentario)
        {
            ctx.Comentario!.Add(comentario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um comentário com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do comentário a ser deletado.</param>
        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = ctx.Comentario!.Find(id)!;

            ctx.Comentario.Remove(comentarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os comentários associados a um paciente com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente para o qual os comentários serão listados.</param>
        /// <returns>Uma lista de objetos Comentario associados ao paciente.</returns>
        public List<Comentario> ListarPorPaciente(Guid id)
        {
            try
            {
                // Certifique-se de que a consulta retorne uma coleção de objetos Comentario
                return ctx.Comentario!.Where(c => c.IdPaciente == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
