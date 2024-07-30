namespace Server.Models
{
    public class PedidoProduto
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
