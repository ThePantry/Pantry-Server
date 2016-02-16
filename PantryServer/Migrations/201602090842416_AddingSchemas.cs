namespace PantryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSchemas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Size = c.String(),
                        SizeTyoe = c.String(),
                        Shop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            AddColumn("dbo.AspNetUsers", "Shop_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Shop_Id");
            AddForeignKey("dbo.AspNetUsers", "Shop_Id", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.AspNetUsers", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.AspNetUsers", new[] { "Shop_Id" });
            DropIndex("dbo.Shops", new[] { "Owner_Id" });
            DropIndex("dbo.Items", new[] { "Shop_Id" });
            DropColumn("dbo.AspNetUsers", "Shop_Id");
            DropTable("dbo.Shops");
            DropTable("dbo.Items");
        }
    }
}
