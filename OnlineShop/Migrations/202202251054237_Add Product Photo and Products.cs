namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductPhotoandProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductPhotoes",
                c => new
                    {
                        ProductPhotoID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileExtension = c.String(),
                        FilePath = c.String(),
                        Products_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductPhotoID)
                .ForeignKey("dbo.Products", t => t.Products_ProductID)
                .Index(t => t.Products_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPhotoes", "Products_ProductID", "dbo.Products");
            DropIndex("dbo.ProductPhotoes", new[] { "Products_ProductID" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductPhotoes");
        }
    }
}
