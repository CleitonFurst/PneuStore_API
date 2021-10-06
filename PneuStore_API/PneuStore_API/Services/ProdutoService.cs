using PneuStore_API.Data;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public class ProdutoService : IProdutoService
    {
        API_Context _context;
        public ProdutoService(API_Context context)
        {
            _context = context;
        }
        public List<Product> All()
        {
            return _context.Products.ToList();
        }

        public Product Get(int? id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }
        public List<Product> ProductByUserRole(string getRole)
        {
            var query1 = from product in _context.Set<Product>()
                         join cart in _context.Set<CartItem>()
                           on product.ProductID equals cart.ProductId
                         where cart.ItemId == getRole
                         select new Product()
                         {
                             ProductID = product.ProductID,
                             ProductName = product.ProductName,
                             UnitPrice = product.UnitPrice,
                             Description = product.Description,
                             ImagePath = product.ImagePath,
                             CategoryID = product.CategoryID

                         };
            return query1.ToList();

        }
    }
}
