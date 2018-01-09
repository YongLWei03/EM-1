namespace EM.EF
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class EMModel : DbContext
  {
    public EMModel()
        : base("name=EMDBConnStr")
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientProperty> ClientProperties { get; set; }
    public virtual DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Client>()
          .HasMany(e => e.ClientProperties)
          .WithRequired(e => e.Client)
          .WillCascadeOnDelete(false);
    }
  }
}
