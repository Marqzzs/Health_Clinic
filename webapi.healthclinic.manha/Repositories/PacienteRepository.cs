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

        public Paciente BuscarPorId(Guid id)
        {
            return ctx.Paciente!.FirstOrDefault(p => p.IdPaciente == id)!;
        }

        public void Cadastrar(Paciente paciente)
        {
            paciente.IdPaciente = Guid.NewGuid();

            ctx.Paciente!.Add(paciente);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente!.Find(id)!;

            ctx.Paciente.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Paciente!.ToList();
        }
    }
}
