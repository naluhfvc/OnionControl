using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> CadastrarCliente(PedidoPlanilhaDTO planilhaDTO);
    }
}
