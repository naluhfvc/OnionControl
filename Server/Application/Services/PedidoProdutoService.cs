using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;

namespace OnionServer.Application.Services
{
    public class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly OnionDbContext _context;
        private readonly IMapper _mapper;

        public PedidoProdutoService(OnionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PedidoProduto> CadastrarPedidoProduto(int pedidoId, int produtoId)
        {
            var pedidoProdutoExiste = await _context.PedidoProdutos.AsNoTracking()
                                        .FirstOrDefaultAsync(pp => pp.PedidoId == pedidoId && pp.ProdutoId == produtoId);

            if (pedidoProdutoExiste == null)
            {
                var pedidoProduto = new PedidoProduto
                {
                    PedidoId = pedidoId,
                    ProdutoId = produtoId
                };

                _context.PedidoProdutos.Add(pedidoProduto);
                await _context.SaveChangesAsync();
                pedidoProdutoExiste = pedidoProduto;
            }

            return pedidoProdutoExiste;
        }
    }
}
