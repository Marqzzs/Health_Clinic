using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IMedico
    {
        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        List<Medico> ListarTodos();

        Medico BuscarPorId(Guid id);

        void Atualizar(Guid id, Medico medico);

        List<Medico> ListarComEspecialidade(Guid id);
    }
}
