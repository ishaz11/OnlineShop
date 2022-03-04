namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphotostoproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Photo1", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Photo2", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Photo3", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Photo3");
            DropColumn("dbo.Products", "Photo2");
            DropColumn("dbo.Products", "Photo1");
        }
    }
}
