using Microsoft.AspNetCore.Mvc;
using Server.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly OnionDbContext _context;

        public ProdutosController(OnionDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
