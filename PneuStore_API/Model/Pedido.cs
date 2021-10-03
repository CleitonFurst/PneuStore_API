﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Model
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
