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
        CartItem Get(int? id);
        bool Create(CartItem c);
        
        bool Update(CartItem c);
        bool Delete(int? id);

        List<CartItem> ProductConsulta(int? id);
        
    }
}
