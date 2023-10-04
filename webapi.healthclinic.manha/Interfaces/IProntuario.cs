using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IProntuario
    {
        void CadastrarProntuario(Prontuario prontuario);

        void Deletar(Guid id);

        List<Prontuario> ListarTodos();

        List<Prontuario> ListarPorPaciente(Guid idPaciente);

        void Atualizar(Guid id, Prontuario prontuario);
    }
}
