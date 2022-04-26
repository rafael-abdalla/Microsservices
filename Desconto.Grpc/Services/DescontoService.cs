using AutoMapper;
using Desconto.Grpc.Entities;
using Desconto.Grpc.Protos;
using Desconto.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Desconto.Grpc.Services
{
    public class DescontoService : DescontoProtoService.DescontoProtoServiceBase
    {
        private readonly IDescontoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DescontoService> _logger;

        public DescontoService(IDescontoRepository repository, IMapper mapper, ILogger<DescontoService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<CupomModel> ObterDesconto(ObterDescontoRequest request,
            ServerCallContext context)
        {
            var cupom = await _repository.ObterPorProdutoNome(request.ProdutoNome);

            if (cupom is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"Desconto para o produto {request.ProdutoNome} não encontrado."));
            }

            var cupomModel = _mapper.Map<CupomModel>(cupom);
            return cupomModel;
        }

        public override async Task<CupomModel> InserirDesconto(InserirDescontoRequest request,
            ServerCallContext context)
        {
            var cupom = _mapper.Map<Cupom>(request.Cupom);
            await _repository.Inserir(cupom);

            return _mapper.Map<CupomModel>(cupom);
        }

        public override async Task<CupomModel> AtualizarDesconto(AtualizarDescontoRequest request,
            ServerCallContext context)
        {
            var cupom = _mapper.Map<Cupom>(request.Cupom);
            await _repository.Atualizar(cupom);
            
            return _mapper.Map<CupomModel>(cupom);
        }

        public override async Task<EliminarDescontoResponse> EliminarDesconto(EliminarDescontoRequest request,
            ServerCallContext context)
        {
            var eliminado = await _repository.Eliminar(request.ProdutoNome);

            return new EliminarDescontoResponse { Sucesso = eliminado };
        }
    }
}
