using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Article");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(f => f.Title).IsUnique();
            builder.Property(f => f.CategoryId).IsRequired();
            builder.Property(f => f.Summary).HasMaxLength(400).IsRequired();
            builder.Property(f => f.Body).HasMaxLength(1000).IsRequired();
            builder.Property(f => f.VisitCount).IsRequired();
            builder.Property(f => f.Active).IsRequired();
            builder.Property(f => f.Url).HasMaxLength(100);
            builder.Property(f => f.H1).HasMaxLength(50);
            builder.Property(f => f.Writer).HasMaxLength(50);
            builder.Property(f => f.WriterPosition).HasMaxLength(50);
            builder.Property(f => f.WriterImageUrl).HasMaxLength(100);
            builder.Property(f => f.Aparat).HasMaxLength(50);
            builder.Property(f => f.Canonical).HasMaxLength(50);
            builder.Property(f => f.PostLabel).HasMaxLength(50);
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Articles)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
