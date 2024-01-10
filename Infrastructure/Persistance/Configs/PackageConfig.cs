using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class PackageConfig : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Country");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.Type).IsRequired();
            builder.Property(f => f.Code).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.Code).IsUnique();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.Price).IsRequired();
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
