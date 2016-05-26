using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PantryServer.Models;
using PantryServer.Models.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace PantryServer.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCollection> Collections { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PantryOrder> PantryOrders { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }

        //uses the fluent api to define relationships specifically  ------ broke!!!
        //protected override void OnModelCreating
        //(DbModelBuilder modelBuilder)
        //{
        //    // 1 to 1 relationship
        //    modelBuilder.Entity<Cart>()
        //        .HasOptional(cart => cart.PantryOrder)
        //        .WithRequired(order => order.Cart);
        //}

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
    }
}