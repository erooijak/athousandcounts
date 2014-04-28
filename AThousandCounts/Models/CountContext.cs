using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AThousandCounts.Models
{
    public class CountContext : DbContext
    {
        public CountContext() : base("AzureSqlConnection")
        {
        }

        public DbSet<CountModel> Counts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}