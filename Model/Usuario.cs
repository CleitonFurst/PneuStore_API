using PneuStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Model
{
    public class Usuario 
    {
        public int UsuarioId {get; set; }
        public string Nome {get; set;}
        public string Endereco { get; set;}

    }
}
