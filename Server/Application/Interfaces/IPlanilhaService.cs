using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IPlanilhaService
    {
        Task<Result> ProcessarPlanilha(IFormFile planilha);
        Task<IEnumerable<PedidoPlanilhaDTO>> LerPlanilha(IFormFile planilha);
        Task<Result> CadastrarDados(IEnumerable<PedidoPlanilhaDTO> listaPedidos);
    }
}
