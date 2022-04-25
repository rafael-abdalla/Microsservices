using Catalogo.Api.Data;
using Catalogo.Api.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ICatalogoContext _context;

        public ProdutoRepository(ICatalogoContext context)
        {
            _context = context;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            var resultado = await _context.Produtos
                .ReplaceOneAsync(filter: g => g.Id == produto.Id, replacement: produto);

            return resultado.IsAcknowledged && resultado.ModifiedCount > 0;
        }

        public async Task<bool> Eliminar(string id)
        {
            FilterDefinition<Produto> filtro = Builders<Produto>.Filter.Eq(p => p.Id, id);

            DeleteResult resultado = await _context.Produtos.DeleteOneAsync(filtro);

            return resultado.IsAcknowledged && resultado.DeletedCount > 0;
        }

        public async Task Inserir(Produto produto) =>
            await _context.Produtos.InsertOneAsync(produto);
        

        public async Task<IEnumerable<Produto>> ObterPorCategoria(string categoria)
        {
            FilterDefinition<Produto> filtro = Builders<Produto>.Filter.Eq(p => p.Categoria, categoria);

            return await _context.Produtos.Find(filtro).ToListAsync();
        }

        public async Task<Produto> ObterPorId(string id) =>
            await _context.Produtos.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Produto>> ObterPorNome(string nome)
        {
            FilterDefinition<Produto> filtro = Builders<Produto>.Filter.ElemMatch(p => p.Nome, nome);

            return await _context.Produtos.Find(filtro).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodos() =>
            await _context.Produtos.Find(p => true).ToListAsync();
    }
}
