using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Post");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Parent)
                  .WithMany()
                  .HasForeignKey(x => x.ParentId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
