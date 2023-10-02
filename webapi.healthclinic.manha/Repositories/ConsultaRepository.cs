using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class ConsultaRepository : IConsulta
    {
        private readonly HealthContext ctx;
        public ConsultaRepository()
        {
            ctx= new HealthContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.Descricao = consulta.Descricao;
                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HorarioConsulta = consulta.HorarioConsulta;
                consultaBuscada.IdMedico = consulta.IdMedico;
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            return ctx.Consulta!.FirstOrDefault(c => c.IdConsulta == id)!;
        }

        public void Cadastrar(Consulta consulta)
        {
            ctx.Consulta!.Add(consulta);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = ctx.Consulta!.Find(id)!;

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> ListarComPaciente(Guid id)
        {
            return ctx.Consulta.Where(c => c.IdPaciente == id).ToList();
        }

        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta.ToList();
        }
    }
}
