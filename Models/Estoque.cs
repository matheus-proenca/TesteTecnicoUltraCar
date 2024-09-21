using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Testetecnico_Ultracar.Models
{
    public class Estoque
    {
        [Key]
        [Required]
        public int EstoqueId { get; set; }
        [Required]
        public int PecaId { get; set; }
        [Required]
        public Peca Peca { get; set; }
        [Required]
        public int Quantidade {  get; set; }
        [Required]
        [ForeignKey("EntregaId")]
        public int EntregaId { get; set; }
        [Required]
        public ICollection<Entrega>? Entregas { get; set; }
        public DateTime Enviado { get; set; } = DateTime.Now;
        public DateTime Entregue { get; set; }
    }
}
