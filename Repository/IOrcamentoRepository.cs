using Testetecnico_Ultracar.Dto;

namespace Testetecnico_Ultracar.Repository
{
    public interface IOrcamentoRepository
    {
        string CreateOrcamento(OrcamentoDto orcamento);
        string AddPeca(int pecaId, int orcamentoId, int quantidade);
        string PecaStatusUpdate(int entregaId);
        ResponseOrcamento GetOrcamento(int orcamentoId);
    }
}
