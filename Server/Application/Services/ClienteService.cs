using AutoMapper;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Interfaces;

namespace OnionServer.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CadastrarCliente(PedidoPlanilhaDTO planilhaDTO)
        {
            var cliente = await _clienteRepository.GetByNumeroDoc(planilhaDTO.NumeroDoc);

            if (cliente == null)
            {
                cliente = _mapper.Map<Cliente>(planilhaDTO);
                await _clienteRepository.AddAsync(cliente);
                _clienteRepository.SaveChanges();
            }

            return cliente;
        }
    }
}
