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

        public PlanilhaController(IPlanilhaService planilhaService)
        {
            _planilhaService = planilhaService;
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
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            var result = await _planilhaService.ProcessarPlanilha(file);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


    }


}
