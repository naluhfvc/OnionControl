using AutoMapper;
using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Mapping
{
    public class OnionProfile: Profile
    {
        public OnionProfile()
        {
            CreateMap<PedidoPlanilhaDTO, Cliente>()
                .ForMember(dest => dest.NumeroDoc, opt => opt.MapFrom(src => src.NumeroDoc))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(src => src.RazaoSocial))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep));

            CreateMap<PedidoPlanilhaDTO, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NumeroPedido))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.ClienteNumeroDoc, opt => opt.MapFrom(src => src.NumeroDoc));
        }
    }
}
