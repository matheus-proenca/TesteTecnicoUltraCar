using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Repository;

namespace Testetecnico_Ultracar.Controllers
{
    [Route("orcamento")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoRepository _repository;
        public OrcamentoController(IOrcamentoRepository orcamentoRepository)
        {
            _repository = orcamentoRepository;
        }

        [HttpPost]
        public IActionResult PostOrcamento([FromBody]OrcamentoDto orcamento)
        {
            string createdOrcamento = _repository.CreateOrcamento(orcamento);
            if(createdOrcamento == null)
            {
                return BadRequest(createdOrcamento);
            }
            return Created("",createdOrcamento);
        }
        [HttpPost("{OrcamentoId}")]
        public IActionResult PostAddPeca(int OrcamentoId,[FromBody] int pecaId,int quantidade)
        {
            string addPecaOrcamento = _repository.AddPeca(pecaId,OrcamentoId,quantidade);
            if(addPecaOrcamento == null)
            {
                return BadRequest(addPecaOrcamento);
            }
            return Ok(addPecaOrcamento);
        }
        [HttpGet("{orcamentoId}")]
        public IActionResult GetOrcamento(int orcamentoId) 
        {
            ResponseOrcamento getOrcamento = _repository.GetOrcamento(orcamentoId);
            if(getOrcamento == null)
            {
                return BadRequest(getOrcamento);
            }
            return Ok(getOrcamento);
        }
        [HttpPost("confirm/{entregaId}")]
        public IActionResult ConfirmEntrega(int entregaId)
        {
            string confirmEntrega = _repository.PecaStatusUpdate(entregaId);
            if(GetOrcamento == null)
            {
                return BadRequest(GetOrcamento);
            }
            return Ok(confirmEntrega);
        }
    }
}
