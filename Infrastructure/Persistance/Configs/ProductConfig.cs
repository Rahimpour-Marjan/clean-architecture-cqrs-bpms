using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Product");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.ProductTypeId).IsRequired();
            builder.Property(f => f.ProductCategoryId).IsRequired();
            builder.Property(f => f.ProductBrandId).IsRequired();
            builder.Property(f => f.H1).HasMaxLength(50);
            builder.Property(f => f.Url).HasMaxLength(100);
            builder.Property(f => f.CodeValue).HasMaxLength(50);
            builder.Property(f => f.Summary).HasMaxLength(500);
            builder.Property(f => f.Description).HasMaxLength(500);
            builder.Property(f => f.Body).HasMaxLength(1000);
            builder.Property(f => f.Latitude).HasMaxLength(15);
            builder.Property(f => f.Longitude).HasMaxLength(15);
            builder.Property(f => f.MetaTagDescription).HasMaxLength(500);
            builder.Property(f => f.Canonical).HasMaxLength(100);
            builder.Property(f => f.Keywords).HasMaxLength(500);
            builder.Property(f => f.IsService).IsRequired();
            builder.Property(f => f.IsCopy).IsRequired();
            builder.Property(f => f.IsPublic).IsRequired();
            builder.Property(f => f.IsSpecial).IsRequired();
            builder.Property(f => f.PayLater).IsRequired();
            builder.Property(f => f.IsExport).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.VideoDemoFileUrl).HasMaxLength(100);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.ProductType)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.ProductTypeId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProductCategory)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.ProductCategoryId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProductBrand)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.ProductBrandId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
