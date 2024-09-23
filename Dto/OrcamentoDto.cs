using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Dto
{
    public class OrcamentoDto
    {
        public string NomeClient {  get; set; }
        public int Cep {  get; set; }
        public string PlacaVeiculo { get; set; }
        public int QuantidadePeca {  get; set; }
    }

    public class ResponseOrcamento
    {
        public int OrcamentoId { get; set; }
        public string NomeCliente { get; set; }
        public string PlacaVeiculo { get; set; }
        public ICollection<Peca> Pecas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
