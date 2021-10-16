using Microsoft.AspNetCore.Identity;
using PneuStore_API.Data;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    public class ProdutoService : IProdutoService
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    {
        API_Context _context;
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public ProdutoService(API_Context context)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            _context = context;
        }
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public List<Product> All()
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            return _context.Products.ToList();
        }

#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public Product Get(int? id)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }


#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public bool Create(Product u)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            try
            {
                u.created = DateTime.Now;
                _context.Products.Add(u);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public bool Delete(int? id)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {   if (!_context.Products.Any(c => c.ProductID == id))
                throw new Exception("Produto não existe");
            try
            {
                _context.Products.Remove(Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public bool Update(Product p)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            try
            {
                p.updated = DateTime.Now;
                _context.Products.Update(p);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public List<Product> ProductByUserRole(string getRole)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            var query1 = from Product in _context.Set<Product>()
                         join user in _context.Set<IdentityUser>()
                           on Product.createdById equals user.Id
                         join userRoles in _context.Set<IdentityUserRole<string>>()
                           on user.Id equals userRoles.UserId
                         join role in _context.Set<IdentityRole>()
                           on userRoles.RoleId equals role.Id
                         where role.Name.ToUpper() == getRole
                         select new Product()
                         {
                             ProductID = Product.ProductID,
                             ProductName = Product.ProductName,
                             UnitPrice = Product.UnitPrice,
                             Description = Product.Description,
                             ImagePath = Product.ImagePath,
                             CategoryID = Product.CategoryID

                         };
            return query1.ToList();

        }
    }
}
