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
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza uma consulta com base em seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser atualizada.</param>
        /// <param name="consulta">Os dados da consulta a serem atualizados.</param>
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

        /// <summary>
        /// Busca uma consulta por seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser buscada.</param>
        /// <returns>O objeto Consulta encontrado ou nulo se não encontrado.</returns>
        public Consulta BuscarPorId(Guid id)
        {
            return ctx.Consulta!.FirstOrDefault(c => c.IdConsulta == id)!;
        }

        /// <summary>
        /// Cadastra uma nova consulta.
        /// </summary>
        /// <param name="consulta">O objeto Consulta a ser cadastrado.</param>
        public void Cadastrar(Consulta consulta)
        {
            ctx.Consulta!.Add(consulta);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma consulta com base em seu ID.
        /// </summary>
        /// <param name="id">O ID da consulta a ser deletada.</param>
        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = ctx.Consulta!.Find(id)!;

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as consultas associadas a um paciente com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do paciente para o qual as consultas serão listadas.</param>
        /// <returns>Uma lista de objetos Consulta associados ao paciente.</returns>
        public List<Consulta> ListarComPaciente(Guid id)
        {
            return ctx.Consulta!.Where(c => c.IdPaciente == id).ToList();
        }

        /// <summary>
        /// Lista todas as consultas cadastradas.
        /// </summary>
        /// <returns>Uma lista de todas as consultas cadastradas.</returns>
        public List<Consulta> ListarTodos()
        {
            return ctx.Consulta!.ToList();
        }
    }
}
