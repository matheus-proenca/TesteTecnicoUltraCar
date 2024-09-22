using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Dto
{
    public class OrcamentoDto
    {
        public string NomeClient {  get; set; }
        public string PlacaVeiculo { get; set; }
        public int PecaId { get; set; }
        public int QuantidadePeca {  get; set; }
        public decimal Valor { get; set; }
    }

    public class ReponseOrcamento
    {
        public int OrcamentoId { get; set; }
        public string NomeClient { get; set; }
        public string PlacaVeiculo { get; set; }
        public ICollection<Peca> Pecas { get; set; }
        public decimal Valor { get; set; }
    }
}
