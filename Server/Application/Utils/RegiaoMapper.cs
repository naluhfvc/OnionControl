using OnionServer.Domain.Enums;
using OnionServer.Domain.Models;

namespace OnionServer.Application.Utils
{
    public class RegiaoMapper
    {
        public static Regiao MapeiaEstadoParaRegiao(Endereco endereco)
        {
            if (endereco.UF == "SP" && endereco.Localidade == "São Paulo") // quando for capital de SP
                return Regiao.SPCapital;

            return endereco.UF switch
            {
                "AC" or "AP" or "AM" or "PA" or "RO" or "RR" or "TO" => Regiao.Norte,
                "AL" or "BA" or "CE" or "MA" or "PB" or "PE" or "PI" or "RN" or "SE" => Regiao.Nordeste,
                "GO" or "MT" or "MS" or "DF" => Regiao.CentroOeste,
                "PR" or "RS" or "SC" => Regiao.Sul,
                _ => Regiao.Sudeste, // só restou estado do sudeste {RJ, MG, ES, SP}
            };
        }

        public static (decimal frete, int diasEntrega) ObterCustoEEntrega(Regiao regiao)
        {
            return regiao switch
            {
                Regiao.Norte or Regiao.Nordeste => (0.30m, 10),   // 30% do valor do produto e 10 dias úteis
                Regiao.CentroOeste or Regiao.Sul => (0.20m, 5),    // 20% do valor do produto e 5 dias úteis
                Regiao.Sudeste => (0.10m, 1),                      // 10% do valor do produto e 1 dia corrido
                Regiao.SPCapital => (0m, 0),                 // Frete gratuito e entrega no mesmo dia
                _ => (0m, 0)                                       // Valor padrão para casos não mapeados
            };
        }
    }
}
