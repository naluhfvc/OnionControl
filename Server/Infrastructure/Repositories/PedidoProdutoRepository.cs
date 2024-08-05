using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class PedidoProdutoRepository: Repository<PedidoProduto>, IPedidoProdutoRepository
    {
        private readonly OnionDbContext _context;

        public PedidoProdutoRepository(OnionDbContext context): base(context)
        {
        }
    }
}
