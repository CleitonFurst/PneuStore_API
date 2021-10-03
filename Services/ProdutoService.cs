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
        public List<Produto> All()
        {
            return _context.Produtos.ToList();
        }

        public Produto Get(int? id)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        }
    }
}
