namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontactnumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ContactNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ContactNumber");
        }
    }
}
