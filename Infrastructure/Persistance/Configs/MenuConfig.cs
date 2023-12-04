using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(f => f.Id).UseHiLo("SiteMenu");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Url).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Icon).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Priority).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();

            builder.HasOne(x => x.Parent)
                        .WithMany(x => x.SubMenus)
                        .HasForeignKey(x => x.ParentId)
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
