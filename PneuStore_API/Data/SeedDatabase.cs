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

            string[] imagem = new string[]
            {
                "https://static.pneustore.com.br/medias/sys_master/images/images/h1f/h73/8969547120670/pneu-aptany-aro-16-ra301-195-45r16-84v-xl-1.jpg",
                "https://static.pneustore.com.br/medias/sys_master/images/images/hf5/h92/8859190951966/pneu-farroad-aro-16-frd16-185-55r16-83v-1.jpg",
                "https://static.pneustore.com.br/medias/sys_master/images/images/hdf/he1/8890239254558/pneu-formula-aro-16-formula-evo-205-55r16-91v-1.jpg"
            };

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

                    //gerando as imagens
                    var imagemP = $"{imagem[random.Next(0, imagem.Length)]}";
                    //adicionando os dados
                    Context.Products.AddRange(new Product
                    {
                        ProductName = produtoCadastrado,
                        UnitPrice = preco,
                        Description = sobreAsParadas,
                        ImagePath = imagemP
                        
                    });

                }



                Context.SaveChanges();

            }


        }
    }
}
