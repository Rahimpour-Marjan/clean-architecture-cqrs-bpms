using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class UserGroupPrivilageConfig : IEntityTypeConfiguration<UserGroupPrivilage>
    {
        public void Configure(EntityTypeBuilder<UserGroupPrivilage> builder)
        {
            builder.Property(f => f.Id).UseHiLo("UserGroupPrivilage");

            builder.Property(f => f.UserGroupId).IsRequired();
            builder.Property(f => f.MenuId).IsRequired();
            builder.Property(f => f.SitePageId).IsRequired();
            builder.Property(f => f.SiteActionId);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.UserGroupPrivilages)
           .HasForeignKey(x => x.UserGroupId)
           .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.Menu)
                 .WithMany(x => x.UserGroupPrivilages)
            .HasForeignKey(x => x.MenuId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SitePage)
              .WithMany(x => x.UserGroupPrivilages)
         .HasForeignKey(x => x.SitePageId)
         .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SiteAction)
              .WithMany(x => x.UserGroupPrivilages)
         .HasForeignKey(x => x.SiteActionId)
         .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
