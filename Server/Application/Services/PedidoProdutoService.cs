using AutoMapper;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Application.Services
{
    public class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly IPedidoProdutoRepository _pedidoProdutoRepository;
        private readonly IMapper _mapper;

        public PedidoProdutoService(IMapper mapper, IPedidoProdutoRepository pedidoProdutoRepository)
        {
            _mapper = mapper;
            _pedidoProdutoRepository = pedidoProdutoRepository;
        }

        public async Task<PedidoProduto> CadastrarPedidoProduto(int pedidoId, int produtoId)
        {
            var pedidoProduto = new PedidoProduto
            {
                PedidoId = pedidoId,
                ProdutoId = produtoId
            };

            await _pedidoProdutoRepository.AddAsync(pedidoProduto);
            _pedidoProdutoRepository.SaveChanges();
                
            return pedidoProduto;
        }
    }
}
