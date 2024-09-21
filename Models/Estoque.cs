using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Testetecnico_Ultracar.Models
{
    public class Estoque
    {
        [Required]
        public int EstoqueId { get; set; }
        [ForeignKey("OrcamentoId")]
        [Required]
        public int OrcamentoId { get; set; }
        [Required]
        public Orcamento? Orcamento { get; set; }
        [ForeignKey("PecaId")]
        [Required]
        public int PecaId {  get; set; }
        [Required]
        public Peca? Peca { get; set; }
        public string EstadoDeEspera { get; set; } = "Espera";
        public DateTime Enviado { get; set; } = DateTime.Now;
        public DateTime Entregue { get; set; }
    }
}
