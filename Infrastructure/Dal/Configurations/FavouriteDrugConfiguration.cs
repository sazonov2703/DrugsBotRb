using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class FavouriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));
        
        builder.HasKey(x => new { x.ProfileId, x.DrugId });
        
        builder.HasOne(f => f.Profile)
            .WithMany(p => p.FavoriteDrugs)
            .HasForeignKey(k => k.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(f => f.Drug)
            .WithMany()
            .HasForeignKey(k => k.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.DrugStore)
            .WithMany()
            .HasForeignKey(x => x.DrugStoreId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}