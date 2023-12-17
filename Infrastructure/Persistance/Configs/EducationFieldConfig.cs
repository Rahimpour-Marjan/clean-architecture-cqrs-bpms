using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class EducationFieldConfig : IEntityTypeConfiguration<EducationField>
    {
        public void Configure(EntityTypeBuilder<EducationField> builder)
        {
            builder.Property(f => f.Id).UseHiLo("EducationField");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
