using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
           // modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//esto es para solucionar este error:
            // may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            //Could not create constraint or index. See previous errors.
            modelBuilder.Entity<Cobro>()
              .HasRequired<ApplicationUser>(cobro => cobro.Usuario);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Obligacion> Obligaciones { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<TipoCobro> TiposCobros { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }

    }
}