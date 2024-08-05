using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;

namespace OnionServer.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly OnionDbContext _context;
        private readonly IMapper _mapper;

        public PedidoService(OnionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Pedido> CadastrarPedido(PedidoPlanilhaDTO planilhaDTO)
        {
            var pedido = await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == planilhaDTO.NumeroPedido);

            if (pedido == null)
            {
                var novoPedido = _mapper.Map<Pedido>(planilhaDTO);
                _context.Pedidos.Add(novoPedido);
                await _context.SaveChangesAsync();
                pedido = novoPedido;
            }

            return pedido;
        }
    }
}
