using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Unit");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.Code).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.Code).IsUnique();
            builder.Property(f => f.ZipCode).HasMaxLength(10);
            builder.Property(f => f.LocationLat).HasMaxLength(15);
            builder.Property(f => f.LocationLong).HasMaxLength(15);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
        }
    }
}
