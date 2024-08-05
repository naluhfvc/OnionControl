using OnionServer.Domain.Models;

namespace OnionServer.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> ObterEndereco(string cep);
    }
}
