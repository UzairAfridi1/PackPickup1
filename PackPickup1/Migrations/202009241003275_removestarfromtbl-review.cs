namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removestarfromtblreview : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "Stars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Stars", c => c.String());
        }
    }
}
