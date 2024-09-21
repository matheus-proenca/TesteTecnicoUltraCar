using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetecnico_Ultracar.Models
{
    public class Peca
    {
        [Required]
        public int PecaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int QuantidadeEstoque { get; set; }
        [ForeignKey("OrcamentoId")]
        [Required]
        public int OrcamentoId { get; set; }
        [Required]
        public Orcamento Orcamento { get; set; }
        [Required]
        public Estoque? Estoque { get; set; }
    }
}
