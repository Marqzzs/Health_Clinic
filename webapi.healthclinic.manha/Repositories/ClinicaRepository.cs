using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Uteis;

namespace webapi.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinica
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }

        /// <summary>
        /// Atualiza os dados de uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser atualizada.</param>
        /// <param name="clinica">Os novos dados da clínica.</param>
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = ctx.Clinica!.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.OpeningTime = clinica.OpeningTime;
                clinicaBuscada.ClosingTime = clinica.ClosingTime;
            }

            ctx.Clinica.Update(clinicaBuscada!);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser buscada.</param>
        /// <returns>A clínica encontrada.</returns>
        public Clinica BuscarPorId(Guid id)
        {
            return ctx.Clinica!.FirstOrDefault(c => c.IdClinica == id)!;
        }

        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="clinica">Os dados da clínica a serem cadastrados.</param>
        public void Cadastrar(Clinica clinica)
        {
            clinica.IdClinica = Guid.NewGuid();

            ctx.Clinica!.Add(clinica);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma clínica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da clínica a ser deletada.</param>
        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = ctx.Clinica!.Find(id)!;

            if (clinicaBuscada != null)
            {
                ctx.Clinica.Remove(clinicaBuscada);
            }
        }

        /// <summary>
        /// Lista todas as clínicas cadastradas.
        /// </summary>
        /// <returns>Uma lista de todas as clínicas.</returns>
        public List<Clinica> ListarTodos()
        {
            return ctx.Clinica!.ToList();
        }
    }
}
