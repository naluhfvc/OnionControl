using OnionServer.Domain.Models;
using OnionServer.Domain.Interfaces;
using OnionServer.Infrastructure.Data;
using OnionServer.Application.DTOs;
using OfficeOpenXml;

namespace OnionServer.Application.Services
{
    public class PlanilhaService : IPlanilhaService
    {
        private readonly OnionDbContext _context;

        public PlanilhaService(OnionDbContext context)
        {
            _context = context;
        }

        async Task<Result> IPlanilhaService.ProcessarPlanilha(IFormFile planilha)
        {
            var listaPedidos = new List<PedidoPlanilhaDTO>();
            try
            {
                using (var package = new ExcelPackage(planilha.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var linhaPedido = new PedidoPlanilhaDTO
                        {
                            NumeroDoc = worksheet.Cells[row, 1].Value.ToString(),
                            RazaoSocial = worksheet.Cells[row, 2].Value.ToString(),
                            Cep = worksheet.Cells[row, 3].Value.ToString(),
                            Produto = worksheet.Cells[row, 4].Value.ToString(),
                            NumeroPedido = int.Parse(worksheet.Cells[row, 5].Value.ToString()),
                            Data = worksheet.Cells[row, 6].Value.ToString()
                        };
                        listaPedidos.Add(linhaPedido);
                    }

                }
                return new Result { Success = true, Message = "Planilha processada com sucesso." };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = $"Erro ao processar a planilha: {ex.Message}" };
            }
        }
    }
}
