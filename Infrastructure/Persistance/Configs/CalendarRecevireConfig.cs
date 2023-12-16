using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CalendarRecevireConfig : IEntityTypeConfiguration<CalendarReceiver>
    {
        public void Configure(EntityTypeBuilder<CalendarReceiver> builder)
        {
            builder.Property(f => f.Id).UseHiLo("CalendarReceiver");

            builder.Property(f => f.CalendarId).IsRequired();
            builder.Property(f => f.ReceiverId).IsRequired();

            builder.HasOne(x => x.Person)
                      .WithMany(x => x.CalendarReceivers)
                      .HasForeignKey(x => x.ReceiverId)
                      .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
