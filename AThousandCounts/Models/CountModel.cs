using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AThousandCounts.Models
{
    public class CountModel
    {
        [Key]
        public int Count { get; set; }
        public string IPAddress { get; set; }
        public bool Completed { get; set; }
    }
}