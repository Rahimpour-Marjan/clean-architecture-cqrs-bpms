using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class SitePageConfig : IEntityTypeConfiguration<SitePage>
    {
        public void Configure(EntityTypeBuilder<SitePage> builder)
        {
            builder.Property(f => f.Id).UseHiLo("MySitePage");
            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Url).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Icon).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Priority).IsRequired();
            builder.Property(f => f.MenuId).IsRequired();
            builder.Property(f => f.Key).HasMaxLength(100).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
