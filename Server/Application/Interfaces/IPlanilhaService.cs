using OnionServer.Application.DTOs;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IPlanilhaService
    {
        Task<Result> ProcessarPlanilha(IFormFile planilha);
    }
}
