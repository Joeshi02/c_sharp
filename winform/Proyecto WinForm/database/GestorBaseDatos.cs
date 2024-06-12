using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Proyecto_WinForm.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WinForm.database
{
    public class GestorBaseDatos : DbContext
    {
        public DbSet<Producto> Productos { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.; Database=SistemaCoder; Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
