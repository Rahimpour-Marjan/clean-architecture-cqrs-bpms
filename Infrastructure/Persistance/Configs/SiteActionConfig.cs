using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class SiteActionConfig : IEntityTypeConfiguration<SiteAction>
    {
        public void Configure(EntityTypeBuilder<SiteAction> builder)
        {
            builder.Property(f => f.Id).UseHiLo("SiteAction");

            builder.Property(f => f.Title).HasMaxLength(200).IsRequired();
            builder.Property(f => f.Controller).HasMaxLength(200).IsRequired();
            builder.Property(f => f.Action).HasMaxLength(30).IsRequired();
            builder.Property(f => f.SitePageId).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.SitePage)
                  .WithMany(x => x.SiteActions)
             .HasForeignKey(x => x.SitePageId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
