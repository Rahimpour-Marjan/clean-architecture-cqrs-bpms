using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(f => f.Id).UseHiLo("User");

            builder.HasIndex(f => f.UserName).IsUnique();
            builder.Property(f => f.UserName).HasMaxLength(20).IsRequired();
            builder.Property(f => f.Password).HasMaxLength(150).IsRequired();
            builder.Property(f => f.Salt).HasMaxLength(150).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(50).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
        }
    }
}
