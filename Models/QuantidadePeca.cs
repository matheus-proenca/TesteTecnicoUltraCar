using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetecnico_Ultracar.Models
{
    public class QuantidadePeca
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuantidadePecaId { get; set; }
        [Required]
        [ForeignKey("OrcamentoId")]
        public int OrcamentoId { get; set; }
        public Orcamento Orcamento {get; set; }
        [Required]
        [ForeignKey("PecaId")]
        public int PecaId { get; set; }
        public Peca Peca { get; set; }
        [Required]
        public int Quantidade {  get; set; }
    }
}
