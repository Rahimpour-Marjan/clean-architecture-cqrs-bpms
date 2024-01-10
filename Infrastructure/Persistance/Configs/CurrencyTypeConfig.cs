using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CurrencyTypeConfig : IEntityTypeConfiguration<CurrencyType>
    {
        public void Configure(EntityTypeBuilder<CurrencyType> builder)
        {
            builder.Property(f => f.Id).UseHiLo("CurrencyType");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.CurrencySign).HasMaxLength(10).IsRequired();
            builder.Property(f => f.UnitPrice).IsRequired();
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
