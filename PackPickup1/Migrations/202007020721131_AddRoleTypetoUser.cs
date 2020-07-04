namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleTypetoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RoleType");
        }
    }
}
