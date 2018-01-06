using EM.Common.Template;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.EF
{
  public class EMContext : DbContext
  {

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DefaultTemplate>().Ignore(t => t.PluginType);
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<DefaultTemplate> Templates { get; set; }
  }
}
