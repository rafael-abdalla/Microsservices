using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo.Api.Entities
{
    public class Produto
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}
