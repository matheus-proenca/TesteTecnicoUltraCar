﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetecnico_Ultracar.Models
{
    public class Peca
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PecaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int QuantidadeEstoque { get; set; }
        public QuantidadePeca? QuantidadePeca { get; set; }
        public Estoque? Estoque { get; set; }
        public Entrega? Entrega { get; set; }
    }
}
