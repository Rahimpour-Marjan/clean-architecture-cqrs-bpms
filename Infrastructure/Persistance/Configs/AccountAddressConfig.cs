using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class AccountAddressConfig : IEntityTypeConfiguration<AccountAddress>
    {
        public void Configure(EntityTypeBuilder<AccountAddress> builder)
        {
            builder.Property(f => f.Id).UseHiLo("State");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.AccountId).IsRequired();
            builder.Property(f => f.FullName).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.FullName).IsUnique();
            builder.Property(f => f.Phone).HasMaxLength(10).IsRequired();
            builder.Property(f => f.ExtraPhone).HasMaxLength(10);
            builder.Property(f => f.CountryId).IsRequired();
            builder.Property(f => f.StateId).IsRequired();
            builder.Property(f => f.CityId).IsRequired();
            builder.Property(f => f.ZoneId).IsRequired();
            builder.Property(f => f.Address).HasMaxLength(400).IsRequired();
            builder.Property(f => f.ZipCode).HasMaxLength(10);
            builder.Property(f => f.PostalCode).HasMaxLength(15).IsRequired();
            builder.Property(f => f.LocationLat).HasMaxLength(15);
            builder.Property(f => f.LocationLong).HasMaxLength(15);
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Account)
              .WithMany(x => x.AccountAddresses)
              .HasForeignKey(x => x.AccountId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Country)
               .WithMany()
               .HasForeignKey(x => x.CountryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.State)
               .WithMany()
               .HasForeignKey(x => x.StateId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.City)
             .WithMany()
             .HasForeignKey(x => x.CityId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Zone)
           .WithMany()
           .HasForeignKey(x => x.ZoneId)
           .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
