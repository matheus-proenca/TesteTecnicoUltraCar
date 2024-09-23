using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Models;
using Testetecnico_Ultracar.Repository;

namespace Testetecnico_Ultracar.Controllers
{
    [Route("peca")]
    [ApiController]
    public class PecaController : ControllerBase
    {
        private readonly IPecaRepository _repository;
        public PecaController(IPecaRepository pecaRepository)
        {
            _repository = pecaRepository;
        }
        [HttpPost]
        public IActionResult PostPeca([FromBody]PecaDto peca)
        {
            string createdPeca = _repository.CreatePeca(peca);
            if (createdPeca == null)
            {
                return BadRequest(createdPeca);
            }
            return Created("",createdPeca);
        }
        [HttpPut("{PecaId}")]
        public IActionResult PutPeca(int PecaId, [FromBody]PecaDto peca)
        {
            string putPeca = _repository.UpdatePeca(PecaId, peca);
            if(putPeca == null)
            {
                return BadRequest(putPeca);
            }
            return Ok(putPeca);
        }
        [HttpGet("{PecaId}")]
        public IActionResult GetPeca(int PecaId)
        {
            ResponsePeca getPeca = _repository.GetPeca(PecaId);
            if(getPeca == null)
            {
                return NotFound();
            }
            return Ok(getPeca);
        }
    }
}
