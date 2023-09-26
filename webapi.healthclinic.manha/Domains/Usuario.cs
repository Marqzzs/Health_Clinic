using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do usuario obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email do usuario e obrigatorio!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve ter de 6 a 60 caracteres")]
        [Required(ErrorMessage = "A senha do usuario e obrigatorio")]
        public string? Senha { get; set; }

        //ref. a tabela de tipousuario
        [Required(ErrorMessage ="Informe o tipo do usuario")]
        public Guid IdTipo { get; set; }

        [ForeignKey(nameof(IdTipo))]
        public TipoUsuario? Tipo { get; set; }
    }
}
