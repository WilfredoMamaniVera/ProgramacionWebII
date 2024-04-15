using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcProyectoWeb.Models;

namespace mvcProyectoWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Modelos de datos Creados es decr datos o tablas a crear 

        public DbSet<Almacen> Almacen { get; set; }
    }
}
