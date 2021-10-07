using Microsoft.EntityFrameworkCore;
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
        public List<CartItem> All()
        {
            return _context.Cart.ToList();
        }

      

        public bool Create(CartItem c)
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

        public CartItem Get(int? id)
        {
            return _context.Cart.Find(id);
        }

        public bool Update(CartItem c)
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

        public List<CartItem> ProductConsulta(int? id)
        {
            var query1 = $"SELECT * FROM Cart WHERE cartId = '{id}'";

            return _context.Cart.FromSqlRaw(query1).ToList();
        }

    }
}
