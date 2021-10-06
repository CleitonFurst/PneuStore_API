using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public interface ICartService
    {
        List<CartItem> All();
        bool Create(CartItem c);
        CartItem Get(int? id);
        bool Update(CartItem c);
        bool Delete(int? id);
      
        
    }
}
