using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Model
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public double Preco { get; set; }
        public string  Descricao { get; set; }
        public string Img { get; set; }

    }
}
