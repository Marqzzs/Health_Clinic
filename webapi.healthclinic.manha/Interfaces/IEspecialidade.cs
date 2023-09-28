using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IEspecialidade
    {
        void Cadastrar(Especialidade especialidade);

        void Deletar(Guid id);

        List<Especialidade> ListarTodos();

        Especialidade BuscarPorId(Guid id);

        void Atualizar(Guid id, Especialidade especialidade);
    }
}
