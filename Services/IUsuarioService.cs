
using Microsoft.AspNetCore.Identity;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public interface IUsuarioService 
    {
        
        List<Usuario> All();
        bool Create(Usuario u);
        Usuario Get(int? id);
        bool Update(Usuario u);
        bool Delete(int? id);
        
        

    }
}
