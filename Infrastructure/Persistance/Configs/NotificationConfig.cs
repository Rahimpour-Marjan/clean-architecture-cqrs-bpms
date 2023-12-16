using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(f => f.Id).UseIdentityColumn();

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Text).IsRequired();
            builder.Property(f => f.ReceiverId).IsRequired();
            builder.Property(f => f.IsRead).IsRequired();
            builder.Property(f => f.Icon).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Link).HasMaxLength(100).IsRequired();
            builder.Property(f => f.IsStar).IsRequired();
            builder.Property(f => f.IsArchive).IsRequired();
            builder.Property(f => f.IsDeleted).IsRequired();

            builder.HasOne(x => x.Person)
                      .WithMany(x => x.Notifications)
                      .HasForeignKey(x => x.ReceiverId)
                      .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
