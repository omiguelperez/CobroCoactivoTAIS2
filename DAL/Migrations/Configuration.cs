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
            DateTime tiempoactual = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second);
            context.TiposObligaciones.AddOrUpdate(tipo => tipo.TipoObligacionId, new TipoObligacion[]
                {
                    new TipoObligacion{TipoObligacionId=1,Nombre = "Tipo Obligacion 1",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoObligacion{TipoObligacionId=2,Nombre = "Tipo Obligacion 2",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoObligacion{TipoObligacionId=3,Nombre = "Tipo Obligacion 3",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    //etc...
                });
            context.TiposPersonas.AddOrUpdate(tipo => tipo.TipoPersonaId, new TipoPersona[]
                {
                    new TipoPersona{TipoPersonaId=1,Nombre = "Natural",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoPersona{TipoPersonaId=2,Nombre = "Juridica",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    //etc...
                });

            context.TiposCobros.AddOrUpdate(tipo => tipo.TipoCobroId, new TipoCobro[]
                {
                    new TipoCobro{TipoCobroId=1,Nombre = "Persuasivo",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoCobro{TipoCobroId=2,Nombre = "Coactivo",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    //etc...
                });

            context.TiposDocumentos.AddOrUpdate(tipo => tipo.TipoDocumentoId, new TipoDocumento[]
                {
                    new TipoDocumento{TipoDocumentoId=1,Nombre = "Tipo Documento 1",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoDocumento{TipoDocumentoId=2,Nombre = "Tipo Documento 2",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    new TipoDocumento{TipoDocumentoId=3,Nombre = "Tipo Documento 3",CreatedAt=tiempoactual,UpdateAt=tiempoactual},
                    //etc...
                });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        

            var personaadmin = new Persona()
            {
                Apellidos = "Lider Proyecto",
                Direccion = "Carrera 13 # 36 - 111",
                Identificacion = "10253652141",
                Nombres = "Soy",
                Sexo = "F",
                Email = "soyellider.14@hotmail.com",
                Nacionalidad = "Colombia",
                PaisNacimiento = "Colombia",
                PaisCorrespondencia = "Colombia",
                Departamento = "Cesar",
                Municipio = "Pueblo Bello",
                FechaNacimiento = new DateTime(1996, 07, 30),
                TipoPersonaId = 1,
                Telefono = 31868754,
                CreatedAt=tiempoactual,
                UpdateAt=tiempoactual
            };

            var user = new ApplicationUser()
            {
                UserName = "lider",
                Email = "liderdetodos@gmail.com",
                EmailConfirmed = true,
                FirstName = "Lider",
                LastName = "Proyecto",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3),
                Persona=personaadmin
            };

            var personasecretaria = new Persona()
            {
                Apellidos = "Secretaria Proyecto",
                Direccion = "Carrera 13 # 36 - 111",
                Identificacion = "10253652142",
                Nombres = "Yo Soy",
                Sexo = "F",
                Email = "soysecretaria.14@hotmail.com",
                Nacionalidad = "Colombia",
                PaisNacimiento = "Colombia",
                PaisCorrespondencia = "Colombia",
                Departamento = "Cesar",
                Municipio = "Valledupar",
                FechaNacimiento = new DateTime(1996, 07, 30),
                TipoPersonaId = 1,
                Telefono = 31500212,
                CreatedAt = tiempoactual,
                UpdateAt = tiempoactual
            };

            var secretaria = new ApplicationUser()
            {
                UserName = "secretaria",
                Email = "secretaria@gmail.com",
                EmailConfirmed = true,
                FirstName = "secretaria",
                LastName = "secretaria",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3),
                Persona=personasecretaria
            };


            manager.Create(user, "lider1*");

            manager.Create(secretaria, "secretaria1*");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Deudor" });
                roleManager.Create(new IdentityRole { Name = "Abogado" });
                roleManager.Create(new IdentityRole { Name = "Lider" });
                roleManager.Create(new IdentityRole { Name = "Secretaria" });
                roleManager.Create(new IdentityRole { Name = "Auxiliar Administrativo" });
            }

            var adminUser = manager.FindByName("lider");
            var secretariaUser = manager.FindByName("secretaria");

            manager.AddToRoles(adminUser.Id, new string[] { "Lider" });

            manager.AddToRoles(secretariaUser.Id, new string[] { "Secretaria" });
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
