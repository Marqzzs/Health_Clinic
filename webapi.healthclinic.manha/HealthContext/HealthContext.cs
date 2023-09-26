using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.manha.Domains;

namespace webapi.healthclinic.manha.HealtClinicContext
{
    public class HealthContext : DbContext
    {
        public DbSet<TipoUsuario>? TipoUsuario { get; set;}
        public DbSet<Especialidade>? Especialidade { get; set;}
        public DbSet<Clinica>? Clinica { get; set;}
        public DbSet<Usuario>? Usuario { get; set;}
        public DbSet<Consulta>? Consulta { get; set;}
        public DbSet<Paciente>? Paciente { get; set;}
        public DbSet<Medico>? Medico { get; set;}
        public DbSet<PresencaConsulta>? PresencaConsulta { get; set;}
        public DbSet<Prontuario>? Prontuario { get; set;}
        public DbSet<Comentario>? Comentario { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE09-S14; DataBase=HealthClinic_Manha; User Id=SA; Pwd=Senai@134; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
