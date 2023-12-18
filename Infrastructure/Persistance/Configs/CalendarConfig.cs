using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CalendarConfig : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Calendar");

            builder.Property(f => f.Subject).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Description).IsRequired();
            builder.Property(f => f.DateRecord).IsRequired();
            builder.Property(f => f.Subject).HasMaxLength(100).IsRequired();
            builder.Property(f => f.EventDate).HasColumnType("char(10)").IsRequired();
            builder.Property(f => f.EventTime).HasColumnType("char(8)").IsRequired();
            builder.Property(f => f.SenderId).IsRequired();
            builder.Property(f => f.NotificationDate).HasColumnType("char(10)");
            builder.Property(f => f.NotificationTime).HasColumnType("char(8)");

            builder.HasOne(x => x.Account)
                      .WithMany(x => x.Calendars)
                      .HasForeignKey(x => x.SenderId)
                      .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
