using System;

namespace Carrinho.Api.Entities
{
    public class CarrinhoCompraItem
    {
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
