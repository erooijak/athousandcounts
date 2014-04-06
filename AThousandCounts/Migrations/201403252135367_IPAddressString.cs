namespace AThousandCounts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IPAddressString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CountModel", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CountModel", "IPAddress", c => c.Int(nullable: false));
        }
    }
}
