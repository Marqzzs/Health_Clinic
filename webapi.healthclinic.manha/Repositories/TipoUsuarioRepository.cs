using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly HealthContext ctx;
        public TipoUsuarioRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            tipoUsuario.IdTipoUsuario = Guid.NewGuid();

            ctx.TipoUsuario!.Add(tipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
