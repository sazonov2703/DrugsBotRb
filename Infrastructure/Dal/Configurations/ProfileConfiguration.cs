using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.ExternalId)
            .IsRequired() 
            .HasMaxLength(150) 
            .HasColumnName(nameof(Profile.ExternalId));

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .HasMaxLength(50)
                .HasColumnName(nameof(Profile.Email));
        });
        
        builder.HasMany(p => p.FavoriteDrugs) 
            .WithOne(f => f.Profile) 
            .HasForeignKey(k => k.ProfileId) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}