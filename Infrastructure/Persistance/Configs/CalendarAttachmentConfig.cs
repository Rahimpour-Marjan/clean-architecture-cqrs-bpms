using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CalendarAttachmentConfig : IEntityTypeConfiguration<CalendarAttachment>
    {
        public void Configure(EntityTypeBuilder<CalendarAttachment> builder)
        {
            builder.Property(f => f.Id).UseHiLo("CalendarAttachment");

            builder.Property(f => f.CalendarId).IsRequired();
            builder.Property(f => f.File).IsRequired();
        }
    }
}
