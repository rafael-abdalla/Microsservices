using Desconto.Api.Entities;
using Desconto.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Desconto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DescontoController : ControllerBase
    {
        private readonly IDescontoRepository _repository;

        public DescontoController(IDescontoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "ObterTodos")]
        public async Task<ActionResult<Cupom>> ObterTodos()
        {
            var cupons = await _repository.ObterTodos();

            if (cupons.Count() == 0)
            {
                return NoContent();
            }

            return Ok(cupons);
        }

        [HttpGet("{produtoNome}", Name = "ObterDesconto")]
        public async Task<ActionResult<Cupom>> ObterDesconto(string produtoNome)
        {
            var cupom = await _repository.ObterPorProdutoNome(produtoNome);
            return Ok(cupom);
        }

        [HttpPost]
        public async Task<ActionResult<Cupom>> Inserir([FromBody] Cupom cupom)
        {
            await _repository.Inserir(cupom);
            return CreatedAtRoute("ObterDesconto",
                new { produtoNome = cupom.ProdutoNome }, cupom);
        }

        [HttpPut]
        public async Task<ActionResult<Cupom>> Atualizar([FromBody] Cupom cupom)
        {
            return Ok(await _repository.Atualizar(cupom));
        }

        [HttpDelete("{produtoNome}", Name = "Eliminar")]
        public async Task<ActionResult<Cupom>> Eliminar(string produtoNome)
        {
            return Ok(await _repository.Eliminar(produtoNome));
        }
    }
}
