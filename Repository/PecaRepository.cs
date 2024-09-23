using Microsoft.AspNetCore.Http.HttpResults;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Repository
{
    public class PecaRepository : IPecaRepository
    {
        private readonly Context _context;

        public PecaRepository(Context context)
        {
            _context = context;
        }
        public string CreatePeca(PecaDto peca)
        {
            Peca createPeca = new Peca
            {
                Name = peca.Nome,
                Valor = peca.valor,
                QuantidadeEstoque = peca.QuantidadeEstoque,
            };

            _context.Peca.Add(createPeca);
            _context.SaveChanges();

            return "Peca criada com sucesso!";
        }

        public ResponsePeca GetPeca(int pecaId)
        {
            Peca getPeca = _context.Peca.Where(p => p.PecaId == pecaId).FirstOrDefault();
            if (getPeca == null)
            {
                return null;
            }

            return new ResponsePeca
            {
                Nome = getPeca.Name,
                valor = getPeca.Valor,
                QuantidadeEstoque = getPeca.QuantidadeEstoque,
            };
        }

        public string UpdatePeca(int pecaId,PecaDto peca)
        {
            Peca getPeca = _context.Peca.Where(p => p.PecaId == pecaId).First();
            if (getPeca == null)
            {
                return null;
            }
            getPeca.Name = peca.Nome;
            getPeca.Valor = peca.valor;
            getPeca.QuantidadeEstoque = peca.QuantidadeEstoque;
            _context.SaveChanges();
            return "Peça atualizada com sucesso!";
        }
    }
}
