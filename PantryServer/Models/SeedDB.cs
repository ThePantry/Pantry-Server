using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PantryServer.Models
{
    public class SeedDB : DropCreateDatabaseIfModelChanges<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            new List<Product>
            {
                new Product { Name = "Strawberry Jam" },
                new Product { Name = "Almond Butter" },
                new Product { Name = "African Hot Sauce" },
                new Product { Name = "White Bread" },
                new Product { Name = "Swiss Cheese" },
                new Product { Name = "Chocolate Cake" },
                new Product { Name = "Pumpkin Hummus" },
                new Product { Name = "Red Pepper Dip" },
                new Product { Name = "South Island Salmon" }
            };

            new List<Shop>
            {
                new Shop { Name = "Aaron Copland & Co", /*Products = product.Single(a => a.Name == "Strawberry Jam")*/},
                new Shop { Name = "Entrees" },
                new Shop { Name = "Broken Food Company" },
                new Shop { Name = "Thoroughbread" },
                new Shop { Name = "Sandra's Fine Foods" },
                new Shop { Name = "MontFoot" },
                new Shop { Name = "Aisha Duo" },
                new Shop { Name = "Happy Food Co" }
            }.ForEach(a => context.Shop.Add(a));
        }
    }
}

