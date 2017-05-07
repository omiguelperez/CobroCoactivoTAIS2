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
            //PARA SOLUCIONAR ERROR:
            //Introducing FOREIGN KEY constraint 'FK_dbo.ObligacionesCobros_dbo.Cobroes_CobroId' on table 'ObligacionesCobros' may cause cycles or multiple cascade paths.Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            //Could not create constraint or index. See previous errors.
            modelBuilder.Entity<Obligacion>()
                         .HasMany(x => x.Cobros)
                         .WithMany(x => x.Obligaciones)
                         .Map(x =>
                         {
                             x.ToTable("ObligacionesCobros"); // third table is named Cookbooks
                            x.MapLeftKey("ObligacionId");
                             x.MapRightKey("CobroId");
                         });

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Obligacion> Obligaciones { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<TipoCobro> TiposCobros { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<TipoObligacion> TiposObligaciones { get; set; }
        public DbSet<TipoPersona> TiposPersonas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }

    }
}