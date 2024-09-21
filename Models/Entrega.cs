﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Testetecnico_Ultracar.Models
{
    public class Entrega
    {
        [Key]
        [Required]
        public int EntregaId { get; set; }
        [Required]
        public int Cep { get; set; }
        [ForeignKey("OrcamentoId")]
        [Required]
        public int OrcamentoId { get; set; }
        [Required]
        public Orcamento? Orcamento { get; set; }
        [ForeignKey("PecaId")]
        [Required]
        public int PecaId { get; set; }
        [Required]
        public ICollection<Peca>? Peca { get; set; }
        [Required]
        public Estoque Estoque { get; set; }
        public string EstadoDeEspera { get; set; } = "Espera";
    }
}
