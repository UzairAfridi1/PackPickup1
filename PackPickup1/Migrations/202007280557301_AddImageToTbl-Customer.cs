namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToTblCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Image");
        }
    }
}
