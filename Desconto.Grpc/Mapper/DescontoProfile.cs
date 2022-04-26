using AutoMapper;
using Desconto.Grpc.Entities;
using Desconto.Grpc.Protos;

namespace Desconto.Grpc.Mapper
{
    public class DescontoProfile : Profile
    {
        public DescontoProfile()
        {
            CreateMap<Cupom, CupomModel>().ReverseMap();
        }
    }
}
