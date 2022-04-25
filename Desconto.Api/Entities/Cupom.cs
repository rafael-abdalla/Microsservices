using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desconto.Api.Entities
{
    public class Cupom
    {
        public Guid Id { get; set; }
        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
