using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Models;

namespace Server.Data
{
    public class OnionDbInitializer
    {
        public static void Seed(OnionDbContext context)
        {
            if (context.Produtos.Any()) return; // Se já houver dados, não adiciona novamente

            context.Produtos.AddRange(
                new Produto { Id = 1, Nome = "Celular", Valor = 1000 },
                new Produto { Id = 2, Nome = "Notebook", Valor = 2000 },
                new Produto { Id = 3, Nome = "Televisão", Valor = 3000 }
            );

            context.SaveChanges();
        }
    }
}
