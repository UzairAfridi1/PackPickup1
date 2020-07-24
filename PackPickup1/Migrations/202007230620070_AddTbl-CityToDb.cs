namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblCityToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropTable("dbo.Cities");
        }
    }
}
