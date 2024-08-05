using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class PedidoRepository: Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(OnionDbContext context): base(context)
        {
        }
    }
}
