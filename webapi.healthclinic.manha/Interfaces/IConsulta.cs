using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IConsulta
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> ListarTodos();

        Consulta BuscarPorId(Guid id);

        void Atualizar(Guid id, Consulta consulta);

        List<Consulta> ListarComPaciente(Guid id);
    }
}
