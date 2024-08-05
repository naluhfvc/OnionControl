using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Repositories;

namespace OnionServer.Infrastructure.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
    }
}
