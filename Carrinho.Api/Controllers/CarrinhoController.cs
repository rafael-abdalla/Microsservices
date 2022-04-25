using Carrinho.Api.Entities;
using Carrinho.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Carrinho.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepository _repository;

        public CarrinhoController(ICarrinhoRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{usuarioNome}", Name = "ObterCarrinho")]
        public async Task<ActionResult<CarrinhoCompra>> ObterCarrinho(string usuarioNome)
        {
            var carrinho = await _repository.ObterPorUsuarioNome(usuarioNome);

            return Ok(carrinho ?? new CarrinhoCompra(usuarioNome));
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoCompra>> Atualizar([FromBody] CarrinhoCompra carrinho)
        {
            return Ok(await _repository.Atualizar(carrinho));
        }

        [HttpDelete("{usuarioNome}", Name = "Eliminar")]
        public async Task<IActionResult> Eliminar(string usuarioNome)
        {
            await _repository.EliminarPorUsuario(usuarioNome);
            return Ok();
        }
    }
}
