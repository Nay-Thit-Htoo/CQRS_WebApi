using Microsoft.EntityFrameworkCore;

namespace CQRS_WebApi;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Biller> Billers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureContext(modelBuilder);
    }

    private void ConfigureContext(ModelBuilder builder)
    {
        builder.Entity<Biller>(x =>
        {
            x.ToTable("Biller");
            x.HasKey(t => t.Id);
        });
    }
}


