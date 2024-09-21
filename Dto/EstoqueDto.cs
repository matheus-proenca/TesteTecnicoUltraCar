namespace Testetecnico_Ultracar.Dto
{
    public class EstoqueDto
    {
    }

    public class ResponseEstoque
    {
        public int EstoqueId { get; set; }
        public string NomePeca { get; set; }
        public int Quantidade { get; set; }
        public int CepEstrega { get; set; }
        public DateTime Enviado { get; set; }
        public DateTime Entregue { get; set; }
    }
}
