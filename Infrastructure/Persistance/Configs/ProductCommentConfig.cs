using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class ProductCommentConfig : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.Property(f => f.Id).UseHiLo("ProductComment");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.ProductId).IsRequired();
            builder.Property(f => f.Approved).IsRequired();
            builder.Property(f => f.NameFamily).HasMaxLength(100).IsRequired();
            builder.Property(f => f.EmailAddress).HasMaxLength(20).IsRequired();
            builder.Property(f => f.Body).HasMaxLength(1000).IsRequired();
            builder.Property(f => f.AnswerString).HasMaxLength(1000);
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Product)
               .WithMany(x => x.ProductComments)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProductCommentParent)
              .WithMany()
              .HasForeignKey(x => x.ProductCommentParentId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
