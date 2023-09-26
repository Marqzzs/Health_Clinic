using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="Comentario e obrigatorio")]
        public string? Descricao { get; set; }

        //referencia a tabela paciente
        [Required(ErrorMessage ="Informe o paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //referencia a tabela consulta
        [Required(ErrorMessage ="Informe a consulta")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
