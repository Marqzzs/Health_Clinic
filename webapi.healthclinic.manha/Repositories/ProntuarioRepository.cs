using Microsoft.Identity.Client;
using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ProntuarioRepository : IProntuario
    {
        private readonly HealthContext ctx;

        public ProntuarioRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza as informações de um prontuário com base no seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser atualizado.</param>
        /// <param name="prontuario">O objeto Prontuario contendo as novas informações.</param>
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario prontuarioBuscado = ctx.Prontuario!.Find(id)!;

            if (prontuarioBuscado != null)
            {
                prontuarioBuscado.Descricao = prontuario.Descricao;
            }
        }

        /// <summary>
        /// Cadastra um novo prontuário no sistema.
        /// </summary>
        /// <param name="prontuario">O objeto Prontuario a ser cadastrado.</param>
        public void CadastrarProntuario(Prontuario prontuario)
        {
            ctx.Prontuario!.Add(prontuario);
        }

        /// <summary>
        /// Deleta um prontuário com base no seu ID.
        /// </summary>
        /// <param name="id">O ID do prontuário a ser deletado.</param>
        public void Deletar(Guid id)
        {
            Prontuario prontuarioBuscado = ctx.Prontuario!.Find(id)!;

            ctx.Prontuario.Remove(prontuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os prontuários de um paciente com base no ID do paciente.
        /// </summary>
        /// <param name="idPaciente">O ID do paciente.</param>
        /// <returns>Uma lista de Prontuario contendo os prontuários do paciente.</returns>
        public List<Prontuario> ListarPorPaciente(Guid idPaciente)
        {
            return ctx.Prontuario!.Where(p => p.IdPaciente == idPaciente).ToList();
        }

        /// <summary>
        /// Lista todos os prontuários cadastrados no sistema.
        /// </summary>
        /// <returns>Uma lista de Prontuario contendo todos os prontuários cadastrados.</returns>
        public List<Prontuario> ListarTodos()
        {
            return ctx.Prontuario!.ToList();
        }
    }
}
