namespace OnionServer.Domain.Models
{
    public class Cliente
    {
        public string NumeroDoc { get; set; }
        public string RazaoSocial { get; set; }
        public string Cep { get; set; }

        public IEnumerable<Pedido> Pedidos { get; set; } = Enumerable.Empty<Pedido>();
    }
}
