using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(f => f.Id).UseHiLo("ProductCategory");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.Url).HasMaxLength(100);
            builder.Property(f => f.Body).HasMaxLength(1000);
            builder.Property(f => f.Canonical).HasMaxLength(50);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.ProductCategoryParent)
               .WithMany(x => x.ProductCategories)
               .HasForeignKey(x => x.ProductCategoryParentId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
