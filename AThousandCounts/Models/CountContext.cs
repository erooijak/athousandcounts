using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AThousandCounts.Models
{
    public class CountContext : DbContext, ICountContext
    {
        public CountContext()
            : base("AzureSqlConnection")
        {
        }

        public IDbSet<CountModel> Counts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}