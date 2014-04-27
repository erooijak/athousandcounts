namespace AThousandCounts.Migrations
{
    using AThousandCounts.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AThousandCounts.Models.CountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AThousandCounts.Models.CountContext db)
        {
            for (int i = 1; i <= 1000; i++)
            {
                db.Counts.AddOrUpdate(
                  c => c.Count,
                  new CountModel { Count = i }  
                );
            }
        }
    }
}
