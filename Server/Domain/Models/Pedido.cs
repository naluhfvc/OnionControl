namespace OnionServer.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public string ClienteNumeroDoc { get; set; } // FK

        public Cliente Cliente { get; set; }
        public IEnumerable<PedidoProduto> PedidosProdutos { get; set; } = new List<PedidoProduto>();
    }
}
