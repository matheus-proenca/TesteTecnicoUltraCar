using Microsoft.EntityFrameworkCore;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly Context _context;

        public EstoqueRepository(Context context)
        {
            _context = context;
        }
        public ResponseEstoque GetEstoque(int id)
        {
            Estoque estoque = _context.Estoque.Where(e => e.EstoqueId == id).Include(Estoque => Estoque.Entrega)
                .ThenInclude(Entrega => Entrega.Peca).FirstOrDefault();
            if (estoque == null)
            {
                return null;
            }

            return new ResponseEstoque
            {
                EstoqueId = estoque.EstoqueId,
                NomePeca = estoque.Entrega.Peca.Name,
                Quantidade = estoque.Entrega.quantidadeEnviada,
                CepEstrega = estoque.Entrega.Cep,
                Enviado = estoque.Enviado,
                Entregue = (DateTime?)estoque.Entregue,
            };
        }
    }
}
