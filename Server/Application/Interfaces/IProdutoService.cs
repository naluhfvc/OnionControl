using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> BuscarProduto(PedidoPlanilhaDTO planilhaDTO);
    }
}
