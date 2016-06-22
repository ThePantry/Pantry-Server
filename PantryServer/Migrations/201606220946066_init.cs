namespace PantryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Heading = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ContactPages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Heading = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Shop_Id = c.Int(),
                        Cart_Id = c.Int(),
                        ShopOrder_Id = c.Int(),
                        ProductCollection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.ShopOrders", t => t.ShopOrder_Id)
                .ForeignKey("dbo.ProductCollections", t => t.ProductCollection_Id)
                .Index(t => t.Shop_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.ShopOrder_Id)
                .Index(t => t.ProductCollection_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PantryOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        DeliveryAddress = c.String(),
                        Instructions = c.String(),
                        NumberOfItems = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CartId = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Instructions = c.String(),
                        NumberOfItems = c.Int(nullable: false),
                        Abandoned = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.PantryOrders", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ShopOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PantryOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PantryOrders", t => t.PantryOrder_Id)
                .Index(t => t.PantryOrder_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ProductCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Heading = c.String(),
                        Content = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "ProductCollection_Id", "dbo.ProductCollections");
            DropForeignKey("dbo.AboutPages", "Id", "dbo.Shops");
            DropForeignKey("dbo.Shops", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PantryOrders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShopOrders", "PantryOrder_Id", "dbo.PantryOrders");
            DropForeignKey("dbo.Products", "ShopOrder_Id", "dbo.ShopOrders");
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Id", "dbo.PantryOrders");
            DropForeignKey("dbo.Carts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.Tags", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ContactPages", "Id", "dbo.Shops");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ShopOrders", new[] { "PantryOrder_Id" });
            DropIndex("dbo.Carts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Carts", new[] { "Id" });
            DropIndex("dbo.PantryOrders", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tags", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ProductCollection_Id" });
            DropIndex("dbo.Products", new[] { "ShopOrder_Id" });
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropIndex("dbo.Products", new[] { "Shop_Id" });
            DropIndex("dbo.ContactPages", new[] { "Id" });
            DropIndex("dbo.Shops", new[] { "User_Id" });
            DropIndex("dbo.AboutPages", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductCollections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ShopOrders");
            DropTable("dbo.Carts");
            DropTable("dbo.PantryOrders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Products");
            DropTable("dbo.ContactPages");
            DropTable("dbo.Shops");
            DropTable("dbo.AboutPages");
        }
    }
}
