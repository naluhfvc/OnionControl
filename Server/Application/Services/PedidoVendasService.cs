using OnionServer.Application.DTOs;
using OnionServer.Application.Interfaces;
using OnionServer.Application.Utils;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Services
{
    public class PedidoVendasService : IPedidoVendasService
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IProdutoService _produtoService;

        public PedidoVendasService(IEnderecoService enderecoService, IProdutoService produtoService)
        {
            _enderecoService = enderecoService;
            _produtoService = produtoService;
        }

        public async Task<PedidoVendasDTO> ObterDetalhesPedido(PedidoPlanilhaDTO pedido, decimal valorProduto)
        {
            var endereco = await _enderecoService.ObterEndereco(pedido.Cep); // pega UF e Cidade
            
            var regiao = RegiaoMapper.MapeiaEstadoParaRegiao(endereco);

            var (frete, diasEntrega) = RegiaoMapper.ObterCustoEEntrega(regiao);

            var valorTotal = valorProduto + (valorProduto * frete); // valor com o preco do frete

            var dataEntregaEstimada = pedido.Data.AddDays(diasEntrega);

            return new PedidoVendasDTO
            {
                NomeCliente = pedido.RazaoSocial,
                ValorFinal = valorTotal,
                DataDeEntrega = dataEntregaEstimada,
                NomeProduto = pedido.Produto,
            };
        }

        public async Task<List<PedidoVendasDTO>>ObterListaVendas()
        {
            var pedidos = ListaPedidosCache.UltimaLista;
            if (pedidos is null)
                throw new Exception("Erro ao obter Lista de Vendas.");

            var listaVendas = new List<PedidoVendasDTO>();

            foreach(var pedido in pedidos)
            {
                var produto = await _produtoService.BuscarProduto(pedido);

                var pedidoInfo = await ObterDetalhesPedido(pedido, produto.Valor);

                listaVendas.Add(pedidoInfo);
            }

            return listaVendas;
        }
    }
}
