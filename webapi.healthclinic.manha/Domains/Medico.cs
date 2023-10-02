using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "CRM do medico e obrigatorio")]
        public string? CRM { get; set; }

        //referencia a tabela Usuario
        [Required(ErrorMessage ="Informe o usuario do medico")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //referencia a tabela especialidade
        [Required(ErrorMessage ="Informe a especialidade do medico")]
        public Guid IdEspecialidade { get; set; }
        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //referencia tabela clinica
        [Required(ErrorMessage ="Informe a clinica do medico")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
