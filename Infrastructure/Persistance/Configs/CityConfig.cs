using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(f => f.Id).UseHiLo("City");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.StateId).IsRequired();
            builder.Property(f => f.Code).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.Code).IsUnique();
            builder.Property(f => f.ZipCode).HasMaxLength(10);
            builder.Property(f => f.LocationLat).HasMaxLength(15);
            builder.Property(f => f.LocationLong).HasMaxLength(15);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);

            builder.HasOne(x => x.State)
               .WithMany(x=>x.Cities)
               .HasForeignKey(x => x.StateId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
