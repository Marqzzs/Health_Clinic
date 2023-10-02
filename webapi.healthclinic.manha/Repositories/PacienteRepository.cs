using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class PacienteRepository : IPaciente
    {
        private readonly HealthContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza os dados de um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser atualizado.</param>
        /// <param name="paciente">Os novos dados do paciente.</param>
        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = ctx.Paciente!.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Nome = paciente.Nome;
                pacienteBuscado.Telefone = paciente.Telefone;
                pacienteBuscado.DataNascimento = paciente.DataNascimento;
            }

            ctx.Paciente.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser buscado.</param>
        /// <returns>O paciente encontrado.</returns>
        public Paciente BuscarPorId(Guid id)
        {
            return ctx.Paciente!.FirstOrDefault(p => p.IdPaciente == id)!;
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">Os dados do paciente a serem cadastrados.</param>
        public void Cadastrar(Paciente paciente)
        {
            paciente.IdPaciente = Guid.NewGuid();

            ctx.Paciente!.Add(paciente);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente a ser deletado.</param>
        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente!.Find(id)!;

            ctx.Paciente.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os pacientes cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os pacientes.</returns>
        public List<Paciente> ListarTodos()
        {
            return ctx.Paciente!.ToList();
        }
    }
}
