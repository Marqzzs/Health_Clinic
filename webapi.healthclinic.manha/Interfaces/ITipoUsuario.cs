using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface ITipoUsuario
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        void Deletar(Guid id);

        List<TipoUsuario> ListarTodos();

        TipoUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
