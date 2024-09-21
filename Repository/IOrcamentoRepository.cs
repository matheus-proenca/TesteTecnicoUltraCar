using Testetecnico_Ultracar.Dto;

namespace Testetecnico_Ultracar.Repository
{
    public interface IOrcamentoRepository
    {
        string CreateOrcamento(OrcamentoDto orcamento);
        string CreateEntregaPeca(int orcamentoId, int pecaId, int cep);
        string PecaStatusUpdate(int orcamentoId,int pecaId);
        ReponseOrcamento GetOrcamento(int orcamentoId);
    }
}
