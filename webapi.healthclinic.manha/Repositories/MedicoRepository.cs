using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;

namespace webapi.healthclinic.manha.Repositories
{
    public class MedicoRepository : IMedico
    {
        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza os dados de um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser atualizado.</param>
        /// <param name="medico">Os novos dados do médico.</param>
        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = ctx.Medico.Find(id);

            if (medicoBuscado != null)
            {
                medicoBuscado.Usuario!.Nome = medico.Usuario!.Nome;
                medicoBuscado.IdClinica = medico.IdClinica;
                medicoBuscado.IdEspecialidade = medico.IdEspecialidade;
            }

            ctx.Medico.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser buscado.</param>
        /// <returns>O médico encontrado ou null se não encontrado.</returns>
        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = ctx.Medico!.Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    CRM = m.CRM,
                    Usuario = new Usuario
                    {
                        Nome = m.Usuario!.Nome
                    },
                    Especialidade = new Especialidade
                    {
                        Titulo = m.Especialidade!.Titulo,
                    },
                    Clinica = new Clinica
                    {
                        RazaoSocial = m.Clinica.RazaoSocial,
                    },
                }).FirstOrDefault(m => m.IdMedico == id);

                return medicoBuscado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">Os dados do médico a serem cadastrados.</param>
        public void Cadastrar(Medico medico)
        {
            medico.IdMedico = Guid.NewGuid();

            ctx.Medico!.Add(medico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do médico a ser deletado.</param>
        public void Deletar(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Find(id)!;

            ctx.Medico.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarComEspecialidade(Guid id)
        {
            return ctx.Medico.Where(m => m.IdEspecialidade == id).ToList();
        }

        /// <summary>
        /// Lista todos os médicos cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os médicos.</returns>
        public List<Medico> ListarTodos()
        {
            return ctx.Medico!.ToList();
        }
    }
}
