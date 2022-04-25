using Carrinho.Api.Entities;
using System.Threading.Tasks;

namespace Carrinho.Api.Repositories
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoCompra> ObterPorUsuarioNome(string usuarioNome);
        Task<CarrinhoCompra> Atualizar(CarrinhoCompra carrinho);
        Task EliminarPorUsuario(string usuarioNome);
    }
}
