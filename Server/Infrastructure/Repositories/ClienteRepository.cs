using Microsoft.EntityFrameworkCore;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OnionDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetByNumeroDoc(string numeroDoc) => await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.NumeroDoc == numeroDoc);
    }
}
