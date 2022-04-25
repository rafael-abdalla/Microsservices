using Desconto.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desconto.Api.Repositories
{
    public interface IDescontoRepository
    {
        Task<Cupom> ObterPorProdutoNome(string nome);
        Task<bool> Inserir(Cupom cupom);
        Task<bool> Atualizar(Cupom cupom);
        Task<bool> Eliminar(string nome);
    }
}
