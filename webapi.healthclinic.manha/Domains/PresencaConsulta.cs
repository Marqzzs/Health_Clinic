using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(PresencaConsulta))]
    public class PresencaConsulta
    {
        [Key]
        public Guid IdPresencaConsulta { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="Situacao e necessaria")]
        public bool Situacao { get; set; }

        //referencia a tabela consulta
        [Required(ErrorMessage ="Informe a consulta")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

        //referencia a tabela paciente
        [Required(ErrorMessage ="Informe o paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
