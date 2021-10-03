using PneuStore_API.Data;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        API_Context _context;
        public UsuarioService(API_Context context)
        {
            _context = context;
        }
        public List<Usuario> All()
        {
            return _context.Usuarios.ToList();
        }
        public bool Create(Usuario u)
        {
            try
            {
                _context.Add(u);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Usuario Get(int? id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }
        public bool Update(Usuario u)
        {
            try
            {
                _context.Update(u);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int? id)
        {
            try
            {
                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
       
    }
}
