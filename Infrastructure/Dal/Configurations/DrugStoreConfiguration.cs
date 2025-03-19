using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName(nameof(DrugStore.DrugNetwork));
        
        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(1)
            .HasColumnName(nameof(DrugStore.Number));

        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(150);
            address.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(150);
            ;
            address.Property(x => x.House)
                .IsRequired()
                .HasMaxLength(150);
            ;
        });
    }
}