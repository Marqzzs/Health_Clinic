using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName ="VARCHAR(500)")]
        [Required(ErrorMessage ="Descricao da consulta e obrigatorio!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data da consulta e obrigatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataConsulta { get; set; }

        //referencia a tabela medico
        [Required(ErrorMessage ="Informe o medico")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //referencia a tabela paciente
        [Required(ErrorMessage ="Informe o paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //referencia a tabela presenca consulta
        public Guid IdPresencaConsulta { get; set; }

        public PresencaConsulta? PresencaConsulta { get; set; }
    }
}
