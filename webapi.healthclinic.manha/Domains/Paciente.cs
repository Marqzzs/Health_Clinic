using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName ="VARCHAR(11)")]
        [Required(ErrorMessage ="Informe o cpf do paciente")]
        public string? CPF { get; set; }

        [Column(TypeName ="VARCHAR(11)")]
        [Required(ErrorMessage ="Informe o telefone do paciente")]
        public string? Telefone { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Informe a data de nascimento do paciente")]
        public DateTime DataNascimento { get; set; }

        //referencia a tabela usuario
        [Required(ErrorMessage ="Informe o usuario do paciente")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
