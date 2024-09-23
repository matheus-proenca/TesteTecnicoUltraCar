using Testetecnico_Ultracar.Dto;

namespace Testetecnico_Ultracar.Repository
{
    public interface IEstoqueRepository
    {
        ResponseEstoque GetEstoque(int id);
    }
}
