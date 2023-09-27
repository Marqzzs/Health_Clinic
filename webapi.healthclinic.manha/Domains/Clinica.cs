using Microsoft.EntityFrameworkCore;
using System;
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

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Razao social obrigatória!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome fantasia obrigatória!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "TIME")] // Use TIME para apenas a hora
        [Required(ErrorMessage = "Horário de abertura obrigatório!")]
        public TimeSpan? HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")] // Use TIME para apenas a hora
        [Required(ErrorMessage = "Horário de fechamento obrigatório!")]
        public TimeSpan? HorarioFechamento { get; set; }
    }
}
