using System.Collections.Generic;
using System.Linq;

namespace Carrinho.Api.Entities
{
    public class CarrinhoCompra
    {
        public CarrinhoCompra()
        {
            Itens = new List<CarrinhoCompraItem>();
        }

        public CarrinhoCompra(string usuarioNome)
        {
            UsuarioNome = usuarioNome;
        }

        public string UsuarioNome { get; set; }
        public List<CarrinhoCompraItem> Itens { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return Itens.Sum(x => x.Preco * x.Quantidade);
            }
        }
    }
}
