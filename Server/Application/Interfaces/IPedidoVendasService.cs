using OnionServer.Application.DTOs;

namespace OnionServer.Application.Interfaces
{
    public interface IPedidoVendasService
    {
        Task<PedidoVendasDTO> ObterDetalhesPedido(PedidoPlanilhaDTO pedido, decimal valorProduto);
        Task<List<PedidoVendasDTO>> ObterListaVendas();
    }
}
