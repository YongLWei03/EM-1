using EM.Common.PluginTemplate;
using System.Data.Entity;

namespace EM.EF
{
  public class EMContext : DbContext
  {

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DefaultTemplate>().HasKey(t => t.FullClassName);
      modelBuilder.Entity<DefaultTemplate>().Ignore(t => t.PluginType);
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<DefaultTemplate> Templates { get; set; }
  }
}
