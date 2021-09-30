using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public interface IProdutoService
    {
        List<Produto> All();
        Produto Get(int? id);

    }
}
