using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Data
{
    public class SeedDatabase 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            int amostra = 5;

            string[] produto = new string[] { "Pneu aro 13", "Pneu aro 14", "Pneu aro 15", "Pneu aro 17", "Pneu aro 21", "Jogo de Pneus aro 13", "Jogo de Pneus aro 14",
                "Jogo de Pneus aro 15", "aJogo de Pneus aro 17", "Jogo de Pneus aro 21", "Pneu de moto dianteiro", "Pneu de moto traseiro" };

            string[] sobre = new string[] { "supimpa", "Produto bão", "xuxu beleza", "Sério?Troca por outro" };
            Random random = new();
            for (int j = 0; j < amostra; j++)
            {
                double preco = random.NextDouble() * 1000;
            }

            using (var Context = new API_Context(serviceProvider.GetRequiredService<DbContextOptions<API_Context>>()))
            {
                if (Context.Products.Any())
                {
                    return;
                }
                for (int i = 0; i < amostra; i++)
                {
                    //gerando produto aleatorio
                    var produtoCadastrado = $"{produto[random.Next(0, produto.Length)]}";

                    //gerando valores
                    double preco = random.NextDouble() * 1000;

                    //gerando descrições
                    var sobreAsParadas = $"{sobre[random.Next(0, sobre.Length)]}";

                    //adicionando os dados
                    Context.Products.AddRange(new Product
                    {
                        ProductName = produtoCadastrado,
                        UnitPrice = preco,
                        Description = sobreAsParadas
                        
                    });

                }



                Context.SaveChanges();

            }


        }
    }
}
