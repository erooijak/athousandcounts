using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AThousandCounts.Models
{
    public interface ICountContext
    {
        IDbSet<CountModel> Counts { get; set; }

        int SaveChanges();
    }

}