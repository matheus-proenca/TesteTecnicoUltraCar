﻿using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Dto
{
    public class EntregaDto
    {
    }

    public class ResponseEntrega
    {
        public int EntregaId { get; set; }
        public int Cep { get; set; }
        public string ClienteNome { get; set; }
        public ICollection<Peca> Pecas { get; set; }
        public string EstadoDeEspera {  get; set; }
    }
    public class ResponseCep
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Unidade { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Estado { get; set; }
        public string? Região { get; set; }
        public string? Uf { get; set; }
        public string? Ibge { get; set; }
        public string? Gia { get; set; }
        public string? Ddd { get; set; }
        public string? Siafi { get; set; }
    }
}
