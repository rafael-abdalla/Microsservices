namespace Carrinho.Api.Entities
{
    public class ConfirmarPedido
    {
        public string UsuarioNome { get; set; }
        public decimal ValorTotal { get; set; }

        // Endereço
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        // Pagamento
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string Expiracao { get; set; }
        public string CVV { get; set; }
        public int MetodoPagamento { get; set; }
    }
}
