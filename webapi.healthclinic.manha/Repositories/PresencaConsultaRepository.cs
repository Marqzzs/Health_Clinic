using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class PresencaConsultaRepository : IPresencaConsulta
    {
        private readonly HealthContext ctx;

        public PresencaConsultaRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Cancela a participação de um paciente em uma consulta.
        /// </summary>
        /// <param name="consultaId">O ID da consulta.</param>
        /// <param name="pacienteId">O ID do paciente.</param>
        public void CancelarParticipacao(Guid consultaId, Guid pacienteId)
        {
            var presenca = ctx.PresencaConsulta.FirstOrDefault(p => p.IdConsulta == consultaId && p.IdPaciente == pacienteId);

            // Verifica se a presença foi encontrada antes de removê-la
            if (presenca != null)
            {
                ctx.PresencaConsulta.Remove(presenca);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todas as presenças de um paciente com base no ID do paciente.
        /// </summary>
        /// <param name="id">O ID do paciente.</param>
        /// <returns>Uma lista de objetos PresencaConsulta associados ao paciente.</returns>
        public List<PresencaConsulta> ListarPresencas(Guid id)
        {
            return ctx.PresencaConsulta!.Where(p => p.IdPaciente == id).ToList();
        }

        /// <summary>
        /// Registra a participação de um paciente em uma consulta.
        /// </summary>
        /// <param name="consultaId">O ID da consulta.</param>
        /// <param name="pacienteId">O ID do paciente.</param>
        public void ParticiparConsulta(Guid consultaId, Guid pacienteId)
        {
            var presenca = new PresencaConsulta
            {
                IdConsulta = consultaId,
                IdPaciente = pacienteId
            };

            ctx.PresencaConsulta!.Add(presenca);

            ctx.SaveChanges();
        }
    }
}
