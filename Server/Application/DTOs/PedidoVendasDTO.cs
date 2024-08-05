namespace OnionServer.Application.DTOs
{
    public class PedidoVendasDTO
    {
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorFinal { get; set; }
        public DateOnly DataDeEntrega {  get; set; }
        public string Regiao { get; set; }
    }
}
