using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testetecnico_Ultracar.Dto;
using Testetecnico_Ultracar.Repository;

namespace Testetecnico_Ultracar.Controllers
{
    [Route("estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepository _repository;
        public EstoqueController(IEstoqueRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{estoqueId}")]
        public IActionResult GetEstoque(int estoqueId) 
        {
            ResponseEstoque getEstoque = _repository.GetEstoque(estoqueId);
            if(getEstoque == null)
            {
               return NotFound();
            }
            return Ok(getEstoque);
        }
    }
}
