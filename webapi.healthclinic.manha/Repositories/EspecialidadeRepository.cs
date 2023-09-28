using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class EspecialidadeRepository : IEspecialidade
    {
        private readonly HealthContext ctx;

        public EspecialidadeRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza uma especialidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser atualizada.</param>
        /// <param name="especialidade">Os novos dados da especialidade.</param>
        public void Atualizar(Guid id, Especialidade especialidade)
        {
            // Busca a especialidade pelo ID
            Especialidade especialidadeBuscada = ctx.Especialidade!.Find(id)!;

            if (especialidadeBuscada != null)
            {
                // Atualiza os dados da especialidade
                especialidadeBuscada.Titulo = especialidade.Titulo;
            }

            // Atualiza a especialidade no contexto e no banco de dados
            ctx.Especialidade.Update(especialidadeBuscada!);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma especialidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser buscada.</param>
        /// <returns>Os dados da especialidade encontrada.</returns>
        public Especialidade BuscarPorId(Guid id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidade!.Find(id)!;

            return especialidadeBuscada;
        }

        /// <summary>
        /// Cadastra uma nova especialidade.
        /// </summary>
        /// <param name="especialidade">Os dados da especialidade a ser cadastrada.</param>
        public void Cadastrar(Especialidade especialidade)
        {
            especialidade.IdEspecialidade = Guid.NewGuid();

            ctx.Especialidade!.Add(especialidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma especialidade pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da especialidade a ser deletada.</param>
        public void Deletar(Guid id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidade.Find(id)!;

            ctx.Especialidade.Remove(especialidadeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as especialidades cadastradas.
        /// </summary>
        /// <returns>Uma lista de todas as especialidades no banco de dados.</returns>
        public List<Especialidade> ListarTodos()
        {
            return ctx.Especialidade.ToList();
        }
    }
}
