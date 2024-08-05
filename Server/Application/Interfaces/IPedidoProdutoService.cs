using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IPedidoProdutoService
    {
        Task<PedidoProduto> CadastrarPedidoProduto(int pedidoId, int produtoId);
    }
}
