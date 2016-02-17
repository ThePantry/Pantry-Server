using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PantryServer.Infrastructure;

namespace PantryServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PantryServer.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

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
        }
    }
}
