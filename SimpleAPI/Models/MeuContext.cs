using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleAPI.Models
{
    public class MeuContext : DbContext
    {
        public MeuContext() : base("name=STRING_CONNECTION") { }


        public DbSet<Usuario> Usuarios { get; set; }
    }
}