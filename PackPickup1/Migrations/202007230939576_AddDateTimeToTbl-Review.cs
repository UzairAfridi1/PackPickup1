namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToTblReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CreateAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "CreateAt");
        }
    }
}
