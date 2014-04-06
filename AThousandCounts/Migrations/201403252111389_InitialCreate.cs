namespace AThousandCounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountModel",
                c => new
                    {
                        Count = c.Int(nullable: false, identity: true),
                        IPAddress = c.Int(nullable: false),
                        WebcamVideoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Count)
                .ForeignKey("dbo.WebcamVideo", t => t.WebcamVideoID, cascadeDelete: true)
                .Index(t => t.WebcamVideoID);
            
            CreateTable(
                "dbo.WebcamVideo",
                c => new
                    {
                        WebcamVideoID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WebcamVideoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountModel", "WebcamVideoID", "dbo.WebcamVideo");
            DropIndex("dbo.CountModel", new[] { "WebcamVideoID" });
            DropTable("dbo.WebcamVideo");
            DropTable("dbo.CountModel");
        }
    }
}
