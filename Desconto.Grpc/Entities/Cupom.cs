using System;

namespace Desconto.Grpc.Entities
{
    public class Cupom
    {
        public Guid Id { get; set; }
        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
