using Newtonsoft.Json;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using System.Text.Json.Serialization;

namespace OnionServer.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ObterEndereco(string cep)
        {
            await Task.Delay(400);

            var url = $"https://viacep.com.br/ws/{cep}/json";
            var response = await _httpClient.GetStringAsync(url);
            dynamic resultado = JsonConvert.DeserializeObject(response);
            if (resultado == null)
            {
                throw new Exception("Localização não encontrada pelo CEP");
            }
            return new Endereco { UF = resultado.uf, Localidade = resultado.localidade };
        }
    }
}
