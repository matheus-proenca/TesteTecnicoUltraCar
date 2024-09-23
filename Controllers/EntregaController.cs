using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Repository;

namespace Testetecnico_Ultracar.Controllers
{
    [Route("entrega")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregaRepository _repository;
        public EntregaController(IEntregaRepository entregaRepository)
        {
            _repository = entregaRepository;
        }
        [HttpGet("{entregaId}")]
        public IActionResult GetEntrega(int entregaId) 
        {
            ResponseEntrega getEntrega = _repository.GetEntrega(entregaId);
            if(getEntrega == null)
            {
                return NotFound();
            }
            return Ok(getEntrega);
        }
        [HttpGet("cep/{entregaId}")]
        public async Task<IActionResult> GetCep(int entregaId)
        {
            ResponseCep getCep = await _repository.GetCep(entregaId);
            if(getCep == null)
            {
                return NotFound();
            }
            return Ok(getCep);
        }
    }
}
