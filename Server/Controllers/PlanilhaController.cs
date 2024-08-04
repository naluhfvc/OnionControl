using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnionServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanilhaController : ControllerBase
    {
        // GET: api/downloadModelo
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
    }

}
