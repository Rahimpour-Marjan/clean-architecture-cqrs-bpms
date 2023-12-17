using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class EducationLevelConfig : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.Property(f => f.Id).UseHiLo("EducationLevel");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
