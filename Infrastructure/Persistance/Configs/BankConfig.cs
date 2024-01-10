using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class BankConfig : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Bank");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
