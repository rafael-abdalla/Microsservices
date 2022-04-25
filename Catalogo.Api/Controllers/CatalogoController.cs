using Catalogo.Api.Entities;
using Catalogo.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public CatalogoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutos()
        {
            var produtos = await _repository.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("{id:length(36)}", Name = "ObterProduto")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public async Task<ActionResult<Produto>> ObterPorId(string id)
        {
            var produto = await _repository.ObterPorId(id);
            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [Route("[action]/{categoria}", Name = "ObterPorCategoria")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterPorCategoria(string categoria)
        {
            if (categoria is null)
            {
                return BadRequest("Categoria inválida");
            }

            var produtos = await _repository.ObterPorCategoria(categoria);

            return Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> Inserir([FromBody] Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Produto inválido");
            }

            await _repository.Inserir(produto);

            return CreatedAtRoute("ObterProduto", new { Id = produto.Id }, produto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Atualizar([FromBody] Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Produto inválido");
            }

            return Ok(await _repository.Atualizar(produto));
        }

        [HttpDelete("{id:length(36)}", Name = "EliminarProduto")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarPorId(string id)
        {
            return Ok(await _repository.Eliminar(id));
        }
    }
}
