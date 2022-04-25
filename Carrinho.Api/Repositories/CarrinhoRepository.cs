using Carrinho.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Carrinho.Api.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IDistributedCache _redisCache;

        public CarrinhoRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<CarrinhoCompra> Atualizar(CarrinhoCompra carrinho)
        {
            await _redisCache.SetStringAsync(carrinho.UsuarioNome,
                JsonSerializer.Serialize(carrinho));

            return await ObterPorUsuarioNome(carrinho.UsuarioNome);
        }

        public async Task EliminarPorUsuario(string usuarioNome) =>
            await _redisCache.RemoveAsync(usuarioNome);

        public async Task<CarrinhoCompra> ObterPorUsuarioNome(string usuarioNome)
        {
            var carrinho = await _redisCache.GetStringAsync(usuarioNome);

            if (string.IsNullOrEmpty(carrinho))
            {
                return null;
            }

            return JsonSerializer.Deserialize<CarrinhoCompra>(carrinho);
        }
    }
}
