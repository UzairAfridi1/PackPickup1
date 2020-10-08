namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrateittotblreview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "RateIt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "RateIt");
        }
    }
}
