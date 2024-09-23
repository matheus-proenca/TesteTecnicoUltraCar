using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetecnico_Ultracar.Models
{
    public class Orcamento
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrcamentoId { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public int Cep {  get; set; }
        [Required]
        public string PlacaVeiculo { get; set; }
        public QuantidadePeca? QuantidadePeca { get; set; }
        [Required]
        public decimal ValorTotal {  get; set; }
        public Entrega? Entrega { get; set; }
    }
}
