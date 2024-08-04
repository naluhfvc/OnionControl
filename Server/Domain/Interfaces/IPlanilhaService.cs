using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Domain.Interfaces
{
    public interface IPlanilhaService
    {
        Task<Result> ProcessarPlanilha(IFormFile planilha);
    }
}
