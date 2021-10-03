using PneuStore_API.Data;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public class CartService : ICartService
    {

        API_Context _context;
        public CartService(API_Context context)
        {
            this._context = context;
        }
        public List<Cart> All()
        {
            return _context.Cart.ToList();
        }

        public bool Create(Cart c)
        {
            try
            {
                _context.Cart.Add(c);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                _context.Cart.Remove(Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Cart Get(int? id)
        {
            return _context.Cart.Find(id);
        }

        public bool Update(Cart c)
        {
            try
            {
                _context.Cart.Update(c);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
