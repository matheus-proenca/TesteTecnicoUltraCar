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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstoqueId { get; set; }
        [Required]
        [ForeignKey("EntregaId")]
        public int EntregaId { get; set; }
        [Required]
        public Entrega Entrega { get; set; }
        public DateTime Enviado { get; set; } = DateTime.Now;
        public DateTime? Entregue { get; set; } = null;
    }
}
