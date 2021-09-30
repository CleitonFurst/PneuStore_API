using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PneuStore_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneuStore_API.Data
{
    public class API_Context : IdentityDbContext
    {
        public API_Context(DbContextOptions<API_Context> options) 
            : base (options) { }
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Produto> Produtos { get; set; }

    }
}
