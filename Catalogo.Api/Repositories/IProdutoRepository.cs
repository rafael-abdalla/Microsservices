using Catalogo.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(string id);
        Task<IEnumerable<Produto>> ObterPorNome(string nome);
        Task<IEnumerable<Produto>> ObterPorCategoria(string categoria);

        Task Inserir(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Eliminar(string id);
    }
}
