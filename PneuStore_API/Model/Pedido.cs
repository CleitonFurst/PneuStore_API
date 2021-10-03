using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Model
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public List<Product> Produtos { get; set; }
    }
}
