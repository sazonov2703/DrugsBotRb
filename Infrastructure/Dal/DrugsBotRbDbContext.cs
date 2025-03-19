using Domain.Entities;
using Infrastructure.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal;

public class DrugsBotRbDbContext : DbContext
{
    public DbSet<Drug> Druds { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<DrugItem> DrugItems { get; set; }
    public DbSet<DrugStore> DrugStores { get; set; }
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new FavouriteDrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("", (options) =>
        {
            options.CommandTimeout(10);
        });
        
    }
}