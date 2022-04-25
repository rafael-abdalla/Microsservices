using Catalogo.Api.Entities;
using MongoDB.Driver;

namespace Catalogo.Api.Data
{
    public interface ICatalogoContext
    {
        IMongoCollection<Produto> Produtos { get; }
    }
}
