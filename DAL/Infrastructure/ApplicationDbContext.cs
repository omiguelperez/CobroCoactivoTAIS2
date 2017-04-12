using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("Contexto", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cobro>()
              .HasRequired<ApplicationUser>(cobro => cobro.Usuario);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<ItemFactura> ItemFacturas { get; set; }
        public DbSet<ProgramacionPago> ProgramacionPagos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Obligacion> Obligaciones { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<TipoCobro> TiposCobros { get; set; }

    }
}