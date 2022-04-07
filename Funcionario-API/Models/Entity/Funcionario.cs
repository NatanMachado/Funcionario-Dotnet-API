using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncionarioApi.Models.Entity
{
    [Table("Funcionario")]
    public class Funcionario
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("nome")]
        [StringLength(100, MinimumLength=3)]
        public string? Nome { get; set; }

        [Column("sobrenome")]
        [StringLength(100, MinimumLength=3)]
        public string? Sobrenome { get; set; }

        [Column("documento")]
        [StringLength(14, MinimumLength=11)]
        public string? Documento { get; set; }

        [Column("setor")]
        [StringLength(100, MinimumLength=3)]
        public string? Setor { get; set; }

        [Column("salario_bruto")]
        public decimal SalarioBruto { get; set; }

        [Column("admissao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Admissao { get; set; }

        [Column("plano_saude")]
        public bool PlanoSaude { get; set; }

        [Column("plano_dentral")]
        public bool PlanoDental { get; set; }

        [Column("vale_transporte")]
        public bool ValeTransporte { get; set; }
    }
}