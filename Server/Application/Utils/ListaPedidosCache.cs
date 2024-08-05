using OnionServer.Application.DTOs;

namespace OnionServer.Application.Utils
{
    public class ListaPedidosCache
    {
        private static IEnumerable<PedidoPlanilhaDTO> _ultimaLista;

        public static IEnumerable<PedidoPlanilhaDTO>? UltimaLista
        {
            get => _ultimaLista;
            set => _ultimaLista = value;
        }
    }
}
