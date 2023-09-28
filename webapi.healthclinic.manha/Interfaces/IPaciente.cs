using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IPaciente
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        List<Paciente> ListarTodos();

        Paciente BuscarPorId(Guid id);

        void Atualizar(Guid id, Paciente paciente);
    }
}
