using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class EducationSubFieldConfig : IEntityTypeConfiguration<EducationSubField>
    {
        public void Configure(EntityTypeBuilder<EducationSubField> builder)
        {
            builder.Property(f => f.Id).UseHiLo("EducationSubField");

            builder.Property(f => f.Title).HasMaxLength(50).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.EducationField)
                     .WithMany(x => x.EducationSubFields)
                     .HasForeignKey(x => x.EducationFieldId)
                     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
