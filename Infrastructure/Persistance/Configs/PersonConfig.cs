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
            builder.HasIndex(f => f.Phone).IsUnique();
            builder.Property(f => f.ExtraPhone1).HasMaxLength(30);
            builder.Property(f => f.ExtraPhone2).HasMaxLength(30);
            builder.Property(f => f.ExtraPhone3).HasMaxLength(30);
            builder.Property(f => f.Fax).HasMaxLength(30);
            builder.Property(f => f.Email).HasMaxLength(100);
            builder.HasIndex(f => f.Email).IsUnique();
            builder.Property(f => f.ExtraEmail).HasMaxLength(100);
            builder.Property(f => f.Website).HasMaxLength(50);
            builder.Property(f => f.Instagram).HasMaxLength(50);
            builder.Property(f => f.Telegram).HasMaxLength(50);
            builder.Property(f => f.WhatsApp).HasMaxLength(50);
            builder.Property(f => f.Linkedin).HasMaxLength(50);
            builder.Property(f => f.Facebook).HasMaxLength(50);
            builder.Property(f => f.Address).HasMaxLength(200);
            builder.Property(f => f.LocationLong).HasMaxLength(15);
            builder.Property(f => f.LocationLat).HasMaxLength(15);
            builder.Property(f => f.Job).HasMaxLength(50);
            builder.Property(f => f.Company).HasMaxLength(100);
            builder.Property(f => f.CompanyNo).HasMaxLength(10);
            builder.HasIndex(f => f.CompanyNo).IsUnique();
            builder.Property(f => f.FatherName).HasMaxLength(50);
            builder.Property(f => f.PersonalNumber).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.PersonalNumber).IsUnique();
            builder.Property(f => f.ReagentName).HasMaxLength(100);
            builder.Property(f => f.ReagentCode).HasMaxLength(10);
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.DigitalSignatureUrl).HasMaxLength(100);
            builder.Property(f => f.ResumeUrl).HasMaxLength(100);
            builder.Property(f => f.WorkingHoursRate).HasColumnType("decimal(18,4)");
        }
    }
}
