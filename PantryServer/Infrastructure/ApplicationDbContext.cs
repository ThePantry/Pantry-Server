using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PantryServer.Models;
using PantryServer.Models.Pages;

namespace PantryServer.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
    }
}