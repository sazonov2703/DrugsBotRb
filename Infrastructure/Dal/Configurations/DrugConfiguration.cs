using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName(nameof(Drug.Name));
        
        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName(nameof(Drug.Manufacturer));

        builder.HasOne(d => d.Country)
            .WithMany(y => y.Drugs)
            .HasForeignKey(k => k.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}