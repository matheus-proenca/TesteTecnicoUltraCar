namespace Testetecnico_Ultracar.Dto
{
    public class PecaDto
    {
        public string Nome { get; set; }
        public decimal valor { get; set; }
        public int QuantidadeEstoque { get; set; }
    }

    public class ResponsePeca
    {
        public int EntregaId { get; set; }
        public string Nome { get; set; }
        public decimal valor { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
