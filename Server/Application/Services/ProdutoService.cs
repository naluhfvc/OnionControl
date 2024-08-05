using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;

namespace OnionServer.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly OnionDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoService(OnionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Produto> BuscarProduto(PedidoPlanilhaDTO planilhaDTO)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Nome == planilhaDTO.Produto);

            return produto;
        }
    }
}
