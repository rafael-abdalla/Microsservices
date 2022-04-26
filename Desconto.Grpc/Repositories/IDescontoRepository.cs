using Desconto.Grpc.Entities;
using System.Threading.Tasks;

namespace Desconto.Grpc.Repositories
{
    public interface IDescontoRepository
    {
        Task<Cupom> ObterPorProdutoNome(string nome);
        Task<bool> Inserir(Cupom cupom);
        Task<bool> Atualizar(Cupom cupom);
        Task<bool> Eliminar(string nome);
    }
}
