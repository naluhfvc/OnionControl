using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> CadastrarPedido(PedidoPlanilhaDTO planilhaDTO);
    }
}
