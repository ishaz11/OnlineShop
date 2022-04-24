namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        UserID = c.Int(),
                        OrderCount = c.Int(nullable: false),
                        Status = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateConfirmed = c.DateTime(nullable: false),
                        DateCompleted = c.DateTime(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ProductID)
                .Index(t => t.UserID);
            
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
                        Photo1 = c.String(),
                        Photo2 = c.String(),
                        Photo3 = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
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
                "dbo.ShopReports",
                c => new
                    {
                        reportID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        Quantity = c.Int(),
                        isAble = c.String(),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        Action = c.String(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.reportID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ProductID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopReports", "UserID", "dbo.Users");
            DropForeignKey("dbo.ShopReports", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductPhotoes", "Products_ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropIndex("dbo.ShopReports", new[] { "UserID" });
            DropIndex("dbo.ShopReports", new[] { "ProductID" });
            DropIndex("dbo.ProductPhotoes", new[] { "Products_ProductID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropTable("dbo.ShopReports");
            DropTable("dbo.ProductPhotoes");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
