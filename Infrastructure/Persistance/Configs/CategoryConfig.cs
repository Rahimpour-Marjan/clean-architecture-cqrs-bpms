using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Category");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.Type).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.Url).HasMaxLength(100);
            builder.Property(f => f.Body).HasMaxLength(1000);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();


            builder.HasOne(x => x.CategoryParent)
              .WithMany(x=>x.Categories)
              .HasForeignKey(x => x.CategoryParentId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
