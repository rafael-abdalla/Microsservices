using Desconto.Grpc.Protos;
using System.Threading.Tasks;

namespace Carrinho.Api.GrpcServices
{
    public class DescontoGrpcService
    {
        private readonly DescontoProtoService.DescontoProtoServiceClient _client;

        public DescontoGrpcService(DescontoProtoService.DescontoProtoServiceClient client)
        {
            _client = client;
        }

        public async Task<CupomModel> ObterDesconto(string produtoNome)
        {
            var request = new ObterDescontoRequest { ProdutoNome = produtoNome };

            return await _client.ObterDescontoAsync(request);
        }
    }
}
