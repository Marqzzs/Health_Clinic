using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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

        [Required(ErrorMessage = "The 'OpeningTime' field is required.")]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm:ss")]
        public TimeSpan? OpeningTime { get; set; }

        [Required(ErrorMessage = "The 'ClosingTime' field is required.")]
        [Column(TypeName = "TIME")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm:ss")]
        public TimeSpan? ClosingTime { get; set; }
    }
}
