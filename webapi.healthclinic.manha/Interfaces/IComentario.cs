using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.Interfaces
{
    public interface IComentario
    {
        void Comentar(Comentario comentario);

        void Deletar(Guid id);
          
        List<Comentario> ListarPorPaciente(Guid id);
    }
}
