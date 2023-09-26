using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; }
        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="Descricao do prontuario e obrigatorio")]
        public string? Descricao { get; set; }

        //referencia a tabela consulta
        [Required(ErrorMessage ="Informe a consulta")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

        //referencia a tabela Paciente
        [Required(ErrorMessage ="Informe o paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set;}

        //referencia a tabela medico
        [Required(ErrorMessage ="Informe o medico")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
