namespace PantryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        Shop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .Index(t => t.Shop_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.Tags", "Product_Id", "dbo.Products");
            DropIndex("dbo.Tags", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Shop_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Products");
        }
    }
}
