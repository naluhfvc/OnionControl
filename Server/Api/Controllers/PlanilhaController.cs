using Microsoft.AspNetCore.Mvc;
using OnionServer.Application.Interfaces;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnionServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanilhaController : ControllerBase
    {
        private readonly IPlanilhaService _planilhaService;
        private readonly IPedidoVendasService _pedidoVendasService;

        public PlanilhaController(IPlanilhaService planilhaService, IPedidoVendasService pedidoVendasService)
        {
            _planilhaService = planilhaService;
            _pedidoVendasService = pedidoVendasService;
        }

        // GET: api/<PlanilhaController>/downloadModelo
        [HttpGet("downloadModelo")]
        public IActionResult GetModelo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "modeloPlanilha.xlsx");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("O arquivo não foi encontrado.");
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "modeloPlanilha.xlsx");
        }

        // POST: api/<PlanilhaControler>/upload
        [HttpPost("upload")]
        public async Task<IActionResult> PostPlanilha(IFormFile file)
        {
            var result = await _planilhaService.ProcessarPlanilha(file);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        // GET api/<PlanilhaController>/listaVendas
        [HttpGet("listaVendas")]
        public async Task<IActionResult> GetListaVendas()
        {
            try
            {
                var listaVendas = await _pedidoVendasService.ObterListaVendas();
                return Ok(listaVendas);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pegar lista de vendas.");
            }
        }
    }


}
