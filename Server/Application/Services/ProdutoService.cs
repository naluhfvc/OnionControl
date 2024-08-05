using AutoMapper;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> BuscarProduto(PedidoPlanilhaDTO planilhaDTO)
        {
            var produto = await _produtoRepository.FindAsync(p => p.Nome.Equals(planilhaDTO.Produto, StringComparison.OrdinalIgnoreCase));

            return produto;
        }
    }
}
