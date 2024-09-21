﻿using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetecnico_Ultracar.Models
{
    public class Orcamento
    {
        [Key]
        [Required]
        public int OrcamentoId { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public string PlacaVeiculo { get; set; }
        [Required]
        public ICollection<Peca>? Peca { get; set; }
        [Required]
        public decimal ValorTotal {  get; set; }
        [Required]
        public Estoque? Estoque { get; set; }
    }
}
