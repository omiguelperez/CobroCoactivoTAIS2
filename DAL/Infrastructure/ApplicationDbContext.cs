using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext,Migrations.Configuration>());
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

            //Para Registrar Departamento Ciudades Etc
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity <Departamento> ().Property(m => m.DepartamentoId)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Municipio>().Property(m => m.MunicipioId)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Pais>().Property(m => m.PaisId)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            base.OnModelCreating(modelBuilder);
        }
        public virtual  DbSet<Persona> Personas { get; set; }
        public virtual  DbSet<Obligacion> Obligaciones { get; set; }
        public virtual  DbSet<Cobro> Cobros { get; set; }
        public virtual  DbSet<TipoCobro> TiposCobros { get; set; }
        public virtual  DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public virtual  DbSet<TipoObligacion> TiposObligaciones { get; set; }
        public virtual  DbSet<TipoPersona> TiposPersonas { get; set; }
        public virtual  DbSet<Documento> Documentos { get; set; }
        public virtual  DbSet<Expediente> Expedientes { get; set; }
        public virtual  DbSet<Pais> Paises { get; set; }
        public virtual  DbSet<Departamento> Departamentos { get; set; }
        public virtual  DbSet<Municipio> Municipios { get; set; }

    }
}