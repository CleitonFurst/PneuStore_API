using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
        public Produto Produto { get; set; }
    }
}
