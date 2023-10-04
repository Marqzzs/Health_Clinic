using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IPresencaConsulta
    {
        void ParticiparConsulta(Guid consultaId, Guid pacienteId);

        void CancelarParticipacao(Guid consultaId, Guid pacienteId);
        List<PresencaConsulta> ListarPresencas(Guid id);
    }
}
