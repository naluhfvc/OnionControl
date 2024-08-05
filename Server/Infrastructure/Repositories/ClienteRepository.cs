using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OnionDbContext context): base(context)
        {
        }
    }
}
