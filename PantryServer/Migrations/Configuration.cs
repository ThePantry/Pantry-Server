using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PantryServer.Infrastructure;

namespace PantryServer.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "daniel@chronicdesign.co.nz",
                EmailConfirmed = true,
                FirstName = "Daniel",
                LastName = "Lewis",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "!QAZxdr5");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Manager" });
                roleManager.Create(new IdentityRole { Name = "Vendor" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByName("SuperPowerUser");

            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });


            context.Products.AddOrUpdate(
                new Product { Id = 1, Name = "Strawberry Jam" },
                new Product { Id = 2, Name = "Almond Butter" },
                new Product { Id = 3, Name = "African Hot Sauce" },
                new Product { Id = 4, Name = "White Bread" },
                new Product { Id = 5, Name = "Swiss Cheese" },
                new Product { Id = 6, Name = "Chocolate Cake" },
                new Product { Id = 7, Name = "Pumpkin Hummus" },
                new Product { Id = 8, Name = "Red Pepper Dip" },
                new Product { Id = 9, Name = "South Island Salmon" }
            );

            context.SaveChanges();

            context.Shops.AddOrUpdate(
                new Shop { Id = 1, Name = "Aaron Copland & Co", Products = context.Products.Where(a => a.Name == "Strawberry Jam").ToList() },
                new Shop { Id = 2, Name = "Entrees" },
                new Shop { Id = 3, Name = "Broken Food Company" },
                new Shop { Id = 4, Name = "Thoroughbread" },
                new Shop { Id = 5, Name = "Sandra's Fine Foods" },
                new Shop { Id = 6, Name = "MontFoot" },
                new Shop { Id = 7, Name = "Happy Food Co" }
            );

            context.SaveChanges();

        }
    }
}

