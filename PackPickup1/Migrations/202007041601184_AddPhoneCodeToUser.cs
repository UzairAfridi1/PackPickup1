namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneCodeToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PhoneCode");
        }
    }
}
