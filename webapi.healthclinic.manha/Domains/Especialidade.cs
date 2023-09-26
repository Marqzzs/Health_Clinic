using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Especialidade))]
    [Index(nameof(Titulo), IsUnique =true)]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Titulo da especilidade e obrigatorio!")]
        public string? Titulo { get; set; }
    }
}
