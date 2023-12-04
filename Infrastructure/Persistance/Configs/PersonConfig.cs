using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistance.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Person");

            builder.Property(f => f.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(f => f.LastName).HasMaxLength(50).IsRequired();
            builder.Property(f => f.NationalCode).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.NationalCode).IsUnique();
            builder.Property(f => f.Phone).HasMaxLength(30);
            builder.Property(f => f.Email).HasMaxLength(200);
            builder.Property(f => f.FatherName).HasMaxLength(50);
            builder.Property(f => f.PersonalNumber).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.PersonalNumber).IsUnique();
            builder.Property(f => f.BirthDate).HasMaxLength(10);
            builder.Property(f => f.IdentityNumber).HasMaxLength(10);
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.EmployeementDate).HasMaxLength(10);
            builder.Property(f => f.WorkingHoursRate).HasColumnType("decimal(18,4)");
            builder.Property(f => f.OrganizationalPost).HasMaxLength(50);
        }
    }
}
