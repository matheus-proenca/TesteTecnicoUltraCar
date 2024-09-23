using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Testetecnico_Ultracar.Repository
{
    public class EntregaRepository : IEntregaRepository
    {
        protected readonly Context _context;
        protected readonly HttpClient _httpClient;
        public EntregaRepository(Context context, HttpClient httpClient) 
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<ResponseCep> GetCep(int entregaId)
        {
            Entrega entrega = _context.Entrega.Where(e => e.EntregaId == entregaId).FirstOrDefault();
            HttpResponseMessage response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{entrega.Cep}/json/");
            if(entrega == null) 
            {
                return null;
            }
            if(response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var getCep = JsonConvert.DeserializeObject<ResponseCep>(jsonResult);
                return new ResponseCep
                {
                    Cep = getCep.Cep,
                    Logradouro = getCep.Logradouro,
                    Complemento = getCep.Complemento,
                    Unidade = getCep.Unidade,
                    Bairro = getCep.Bairro,
                    Localidade = getCep.Localidade,
                    Estado = getCep.Estado,
                    Regiao = getCep.Regiao,
                    Uf = getCep.Uf,
                    Ibge = getCep.Ibge,
                    Gia = getCep.Gia,
                    Ddd = getCep.Ddd,
                    Siafi = getCep.Siafi,
                };
            }
            else
            {
                return null;
            }
        }

        public ResponseEntrega GetEntrega(int entregaId)
        {
            Entrega entrega = _context.Entrega.Where(e => e.EntregaId == entregaId).Include(Entrega => Entrega.Orcamento)
                .ThenInclude(Orcamento => Orcamento.QuantidadePeca).ThenInclude(QuantidadePeca => QuantidadePeca.Peca).FirstOrDefault();
            if (entrega == null) 
            {
                return null;
            }
            return new ResponseEntrega {
                EntregaId = entrega.EntregaId,
                Cep = entrega.Cep,
                ClienteNome = entrega.Orcamento.NomeCliente,
                Peca = entrega.Orcamento.QuantidadePeca.Peca,
                QuantidadePeca = entrega.Orcamento.QuantidadePeca.Quantidade,
                EstadoDeEspera = entrega.EstadoDeEspera,
            };
        }
    }
}
