using Testetecnico_Ultracar.Dto;

namespace Testetecnico_Ultracar.Repository
{
    public interface IEntregaRepository
    {
        ResponseEntrega GetEntrega(int entregaId);
        Task<ResponseCep> GetCep(int entregaId);
    }
}
