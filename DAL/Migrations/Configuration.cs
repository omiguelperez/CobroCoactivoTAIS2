namespace DAL.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        
            var user = new ApplicationUser()
            {
                UserName = "lider",
                Email = "liderdetodos@gmail.com",
                EmailConfirmed = true,
                FirstName = "Lider",
                LastName = "Proyecto",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "passwordlider1*");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Deudor" });
                roleManager.Create(new IdentityRole { Name = "Abogado" });
                roleManager.Create(new IdentityRole { Name = "Lider" });
                roleManager.Create(new IdentityRole { Name = "Secretaria" });
                roleManager.Create(new IdentityRole { Name = "Auxiliar Administrativo" });
            }

            var adminUser = manager.FindByName("lider");

            manager.AddToRoles(adminUser.Id, new string[] { "Lider" });

            context.TiposObligaciones.AddOrUpdate(tipo => tipo.TipoObligacionId, new TipoObligacion[]
                {
                    new TipoObligacion{TipoObligacionId=1,Nombre = "Tipo Obligacion 1",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoObligacion{TipoObligacionId=2,Nombre = "Tipo Obligacion 2",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoObligacion{TipoObligacionId=3,Nombre = "Tipo Obligacion 3",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    //etc...
                });
            context.TiposPersonas.AddOrUpdate(tipo => tipo.TipoPersonaId, new TipoPersona[]
                {
                    new TipoPersona{TipoPersonaId=1,Nombre = "Natural",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoPersona{TipoPersonaId=2,Nombre = "Juridica",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    //etc...
                });

            context.TiposCobros.AddOrUpdate(tipo => tipo.TipoCobroId, new TipoCobro[]
                {
                    new TipoCobro{TipoCobroId=1,Nombre = "Persuasivo",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoCobro{TipoCobroId=2,Nombre = "Coactivo",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    //etc...
                });

            context.TiposDocumentos.AddOrUpdate(tipo => tipo.TipoDocumentoId, new TipoDocumento[]
                {
                    new TipoDocumento{TipoDocumentoId=1,Nombre = "Tipo Documento 1",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoDocumento{TipoDocumentoId=2,Nombre = "Tipo Documento 2",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    new TipoDocumento{TipoDocumentoId=3,Nombre = "Tipo Documento 3",CreatedAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second),UpdateAt=new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second)},
                    //etc...
                });
            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
