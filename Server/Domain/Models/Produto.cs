namespace OnionServer.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public IEnumerable<PedidoProduto> PedidosProdutos { get; set; }
    }
}
