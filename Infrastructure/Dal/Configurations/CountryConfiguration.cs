using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName(nameof(Country.Name));
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName(nameof(Country.Code));
        
        builder.HasMany(x => x.Drugs)
            .WithOne(d => d.Country)
            .HasForeignKey(k => k.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}