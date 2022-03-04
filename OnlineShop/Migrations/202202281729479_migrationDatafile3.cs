namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationDatafile3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Photo1", c => c.String());
            AlterColumn("dbo.Products", "Photo2", c => c.String());
            AlterColumn("dbo.Products", "Photo3", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Photo3", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Photo2", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Photo1", c => c.String(nullable: false));
        }
    }
}
