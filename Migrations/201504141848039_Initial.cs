namespace WebApiHarjoitusTyo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DigSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        xCoord = c.Int(nullable: false),
                        yCoord = c.Int(nullable: false),
                        treasureValue = c.Int(nullable: false),
                        isClaimed = c.Boolean(nullable: false),
                        isEmpty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DigSites");
        }
    }
}
