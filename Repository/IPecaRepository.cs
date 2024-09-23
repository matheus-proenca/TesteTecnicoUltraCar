using Testetecnico_Ultracar.Dto;

namespace Testetecnico_Ultracar.Repository
{
    public interface IPecaRepository
    {
        string CreatePeca(PecaDto peca);
        ResponsePeca GetPeca(int pecaId);
        string UpdatePeca(int pecaId,PecaDto peca);
    }
}
