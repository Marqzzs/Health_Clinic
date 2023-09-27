using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IClinica
    {
        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        List<Clinica> ListarTodos();

        Clinica BuscarPorId(Guid id);

        void Atualizar(Guid id, Clinica clinica);
    }
}
