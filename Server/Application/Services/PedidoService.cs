using AutoMapper;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IMapper mapper, IPedidoRepository pedidoRepository)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> CadastrarPedido(PedidoPlanilhaDTO planilhaDTO)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(planilhaDTO.NumeroPedido);

            if (pedido == null)
            {
                pedido = _mapper.Map<Pedido>(planilhaDTO);
                await _pedidoRepository.AddAsync(pedido);
                _pedidoRepository.SaveChanges();
            }

            return pedido;
        }
    }
}
