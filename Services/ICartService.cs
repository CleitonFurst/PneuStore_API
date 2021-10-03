using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public interface ICartService
    {
        List<Produto> All();
        bool Create(Cart c);
        Cart Get(int? id);
        bool Update(Cart c);
        bool Delete(int? id);
    }
}
