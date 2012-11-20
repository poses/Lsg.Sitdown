using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Lsg.Sitdown.Models;
using Microsoft.Data.Schema.SchemaModel;

namespace Lsg.Sitdown
{
    public class SitdownContext : DbContext
    {
        public SitdownContext() : base("name=Sitdown")
        {
            
        }
        public DbSet<DailyEntry> DailyEntries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}