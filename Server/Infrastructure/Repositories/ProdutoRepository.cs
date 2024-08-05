using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class ProdutoRepository: Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(OnionDbContext context): base(context)
        {
        }
    }
}
