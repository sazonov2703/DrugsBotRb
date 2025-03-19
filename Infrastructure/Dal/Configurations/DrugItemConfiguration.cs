using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Cost)
            .HasColumnType("decimal(9,2)")
            .IsRequired();
        
        builder.Property(x => x.Count)
            .HasColumnType("int")
            .IsRequired();
        
        builder.HasOne(di => di.Drug)
            .WithMany(d => d.DrugItems)
            .HasForeignKey(k => k.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(di => di.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(k => k.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}