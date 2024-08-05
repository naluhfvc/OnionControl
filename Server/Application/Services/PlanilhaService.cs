using OnionServer.Domain.Models;
using OnionServer.Application.DTOs;
using OfficeOpenXml;
using OnionServer.Domain.Validators;
using OnionServer.Application.Interfaces;
using AutoMapper;
using OnionServer.Application.Utils;

namespace OnionServer.Application.Services
{
    public class PlanilhaService : IPlanilhaService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoProdutoService _pedidoProdutoService;

        public PlanilhaService(
            IMapper mapper,
            IClienteService clienteService,
            IProdutoService produtoService,
            IPedidoService pedidoService,
            IPedidoProdutoService pedidoProdutoService
            )
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _produtoService = produtoService;
            _pedidoService = pedidoService;
            _pedidoProdutoService = pedidoProdutoService;
        }

        public async Task<Result> CadastrarDados(IEnumerable<PedidoPlanilhaDTO> listaPedidosDTO)
        {
            if (listaPedidosDTO == null || !listaPedidosDTO.Any())
                return new Result { Success = false, Message = "A planilha não possui dados." };
            try
            {
                foreach (var pedidoDTO in listaPedidosDTO)
                {
                    var cliente = await _clienteService.CadastrarCliente(pedidoDTO);
                    var produto = await _produtoService.BuscarProduto(pedidoDTO);

                    if (produto != null)
                    {
                        var pedido = await _pedidoService.CadastrarPedido(pedidoDTO);
                        var pedidoProduto = await _pedidoProdutoService.CadastrarPedidoProduto(pedido.Id, produto.Id);
                    }
                }

                return new Result { Success = true, Message = "Informações da planilha cadastradas com sucesso." };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<IEnumerable<PedidoPlanilhaDTO>> LerPlanilha(IFormFile planilha)
        {
            if (planilha == null) throw new Exception("O Arquivo é nulo.");

            var listaPedidos = new List<PedidoPlanilhaDTO>();


            using (var package = new ExcelPackage(planilha.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var docNumero = worksheet.Cells[row, 1].Value;
                    if (docNumero is null) continue;

                    var linhaPedido = new PedidoPlanilhaDTO
                    {
                        NumeroDoc = PlanilhaValidators.ValidarNumeroDoc(worksheet.Cells[row, 1].Value.ToString()!.Trim()),
                        RazaoSocial = worksheet.Cells[row, 2].Value.ToString()!.Trim(),
                        Cep = PlanilhaValidators.ValidarCEP(worksheet.Cells[row, 3].Value.ToString()!.Trim()),
                        Produto = worksheet.Cells[row, 4].Value.ToString()!.Trim(),
                        NumeroPedido = int.Parse(worksheet.Cells[row, 5].Value.ToString()!.Trim()),
                        Data = PlanilhaValidators.FormatarDataParaDateOnly(worksheet.Cells[row, 6].Value.ToString()!.Trim())
                    };
                    listaPedidos.Add(linhaPedido);
                }

            }

            return listaPedidos;
        }

        public async Task<Result> ProcessarPlanilha(IFormFile planilha)
        {
            if (planilha == null) return new Result
            {
                Success = false,
                Message = "O arquivo é nulo."
            };

            try
            {
                var pedidos = await LerPlanilha(planilha);
                ListaPedidosCache.UltimaLista = pedidos;
                return await CadastrarDados(pedidos);
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}

