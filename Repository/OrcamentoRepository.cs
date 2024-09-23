using Microsoft.EntityFrameworkCore;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar.Repository
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly Context _context;
        public OrcamentoRepository(Context context)
        {
            _context = context;
        }

        public string AddPeca(int pecaId, int orcamentoId, int quantidade)
        {
            Peca peca = _context.Peca.Where(p => p.PecaId == pecaId).FirstOrDefault();
            if (peca == null)
            {
                return "Essa peça não existe no estoque";
            }
            Orcamento orcamento = _context.Orcamento.Where(p => p.OrcamentoId == orcamentoId).FirstOrDefault();
            if (orcamento == null)
            {
                return "Esse orçamento não existe";
            }
            orcamento.ValorTotal = orcamento.ValorTotal + (peca.Valor * quantidade);
            QuantidadePeca addPeça = new QuantidadePeca
            {
                OrcamentoId = orcamentoId,
                PecaId = pecaId,
                Quantidade = quantidade,
            };
            _context.QuantidadePeca.Add(addPeça);
            Entrega addEntrega = new Entrega
            {
                Cep = orcamento.Cep,
                OrcamentoId = orcamento.OrcamentoId,
                Orcamento = orcamento,
                PecaId = peca.PecaId,
                Peca = peca,
                quantidadeEnviada = quantidade,
            };
            _context.Entrega.Add(addEntrega);
            Estoque addEstoque = new Estoque
            {
                EntregaId = orcamento.Entrega.EntregaId,
                Enviado = DateTime.Now.ToUniversalTime(),
                Entrega = orcamento.Entrega,
            };
            _context.Estoque.Add(addEstoque);
            _context.SaveChanges();
            return "Peça adicionada com sucesso!";
        }

        public string CreateOrcamento(OrcamentoDto orcamento)
        {
            Orcamento orcamentos = new Orcamento
            {
                NomeCliente = orcamento.NomeClient,
                Cep = orcamento.Cep,
                PlacaVeiculo = orcamento.PlacaVeiculo,
                ValorTotal = 0
            };
            _context.Orcamento.Add(orcamentos);
            _context.SaveChanges();
            return "Orçamento criado com sucesso!";
        }

        public ResponseOrcamento GetOrcamento(int orcamentoId)
        {
            Orcamento getOrcamento = _context.Orcamento.Where(o => o.OrcamentoId == orcamentoId).Include(o => o.QuantidadePeca)
                .ThenInclude(e => e.Peca).FirstOrDefault();
            if (getOrcamento == null)
            {
                return null;
            }

            return new ResponseOrcamento
            {
                OrcamentoId = getOrcamento.OrcamentoId,
                NomeCliente = getOrcamento.NomeCliente,
                PlacaVeiculo = getOrcamento.PlacaVeiculo,
                Pecas =
                [
                    getOrcamento.QuantidadePeca.Peca,
                ],
                ValorTotal = getOrcamento.ValorTotal,
            };
        }

        public string PecaStatusUpdate(int entregaId)
        {
            Entrega entrega = _context.Entrega.Where(e => e.EntregaId == entregaId).FirstOrDefault();
            Peca peca = _context.Peca.Where(p => p.Entrega.EntregaId == entregaId).FirstOrDefault();
            Estoque estoque = _context.Estoque.Where(e => e.Entrega.EntregaId == entregaId).FirstOrDefault();
            if(entrega == null || entrega.EstadoDeEspera != "Espera")
            {
                return "A peça ja foi entregue ou não a ordem de entrega";
            }
            entrega.EstadoDeEspera = "Entregue";
            peca.QuantidadeEstoque = -entrega.quantidadeEnviada;
            estoque.Entregue = DateTime.Now.ToUniversalTime();
            _context.SaveChanges();
            return "Peça recebida com sucesso";
        }
    }
}
