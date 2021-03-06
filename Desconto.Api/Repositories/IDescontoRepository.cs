using Desconto.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desconto.Api.Repositories
{
    public interface IDescontoRepository
    {
        Task<IEnumerable<Cupom>> ObterTodos();
        Task<Cupom> ObterPorProdutoNome(string nome);
        Task<bool> Inserir(Cupom cupom);
        Task<bool> Atualizar(Cupom cupom);
        Task<bool> Eliminar(string nome);
    }
}
