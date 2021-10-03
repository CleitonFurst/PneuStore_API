using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Data
{
    public class SeedDatabase 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new API_Context(
                serviceProvider.GetRequiredService<DbContextOptions<API_Context>>()))
            {
                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category
                    {                      
                        CategoryName = "Cars"
                    });                   
                    context.SaveChanges();
                }


                if (!context.Products.Any())
                {
                    context.Products.Add(new Product
                    {                       
                        ProductName = "Convertible Car",
                        Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                                      "Power it up and let it go!",
                        ImagePath = "carconvert.png",
                        UnitPrice = 22.50,
                        CategoryID = 1
                    });                   
                    context.SaveChanges();
                }
            
            }
        }
    }
}
