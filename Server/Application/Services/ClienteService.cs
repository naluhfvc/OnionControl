using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Domain.Models;
using OnionServer.Infrastructure.Data;

namespace OnionServer.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly OnionDbContext _context ;
        private readonly IMapper _mapper;

        public ClienteService(OnionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cliente> CadastrarCliente(PedidoPlanilhaDTO planilhaDTO)
        {
            var cliente = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(cliente => cliente.NumeroDoc == planilhaDTO.NumeroDoc);

            if (cliente == null)
            {
                cliente = _mapper.Map<Cliente>(planilhaDTO);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
            }

            return cliente;
        }
    }
}
