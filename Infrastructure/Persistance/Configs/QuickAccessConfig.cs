using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class QuickAccessConfig : IEntityTypeConfiguration<QuickAccess>
    {
        public void Configure(EntityTypeBuilder<QuickAccess> builder)
        {
            builder.Property(f => f.Id).UseHiLo("MyQuickAccess");
            builder.Property(f => f.SitePageId).IsRequired();
            builder.Property(f => f.UserId).IsRequired();
            builder.Property(f => f.Priority).IsRequired();
        }
    }
}
