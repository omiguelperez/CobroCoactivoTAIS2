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
