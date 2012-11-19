using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Lsg.Sitdown.Models;

namespace Lsg.Sitdown
{
    public class SitdownContext : DbContext
    {
        public SitdownContext() : base("name=Sitdown")
        {
            
        }
        public DbSet<DailyEntry> DailyEntries { get; set; }
    }
}