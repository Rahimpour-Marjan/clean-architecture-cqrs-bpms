using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class UserGroupConfig : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.Property(f => f.Id).UseHiLo("UserGroup");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.IsEditable).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.UserGroupParent)
                .WithMany()
                .HasForeignKey(x => x.UserGroupParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
