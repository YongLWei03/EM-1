using EM.Common.PluginTemplate;
using System.Data.Entity;

namespace EM.EF
{
  public class EMContext : DbContext
  {

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DefaultPluginTemplate>().HasKey(t => t.FullClassName);
      modelBuilder.Entity<DefaultPluginTemplate>().Ignore(t => t.PluginType);
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<DefaultPluginTemplate> Templates { get; set; }
  }
}
