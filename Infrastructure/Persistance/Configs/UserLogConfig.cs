using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class UserLogConfig : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.Property(f => f.Id).UseHiLo("User");

            builder.Property(f => f.Type).IsRequired();
            builder.Property(f => f.IP).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Device).HasMaxLength(100).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

        }
    }
}
