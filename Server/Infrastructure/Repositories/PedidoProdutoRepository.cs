using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class PedidoProdutoRepository: Repository<PedidoProduto>, IPedidoProdutoRepository
    {
        public PedidoProdutoRepository(OnionDbContext context): base(context)
        {
        }
    }
}
