using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Razao social obrigatoria!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome fantasia obrigatoria!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatorio")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereco obrigatorio!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de abertura obrigatorio!")]
        public DateTime HorarioAbertura { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de fechamento obrigatorio!")]
        public DateTime HorarioFechamento { get; set; }
    }
}
