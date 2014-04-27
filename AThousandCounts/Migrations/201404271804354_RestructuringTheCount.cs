namespace AThousandCounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestructuringTheCount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CountModel", "WebcamVideoID", "dbo.WebcamVideo");
            DropIndex("dbo.CountModel", new[] { "WebcamVideoID" });
            AddColumn("dbo.CountModel", "Completed", c => c.Boolean(nullable: false));
            DropColumn("dbo.CountModel", "WebcamVideoID");
            DropTable("dbo.WebcamVideo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WebcamVideo",
                c => new
                    {
                        WebcamVideoID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WebcamVideoID);
            
            AddColumn("dbo.CountModel", "WebcamVideoID", c => c.Int(nullable: false));
            DropColumn("dbo.CountModel", "Completed");
            CreateIndex("dbo.CountModel", "WebcamVideoID");
            AddForeignKey("dbo.CountModel", "WebcamVideoID", "dbo.WebcamVideo", "WebcamVideoID", cascadeDelete: true);
        }
    }
}
