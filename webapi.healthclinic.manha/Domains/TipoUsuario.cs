using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(TipoUsuario))]
    [Index(nameof(Titulo), IsUnique =true)]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Titulo do tipo do usuario e obrigatorio!")]
        public string? Titulo { get; set; }
    }
}
