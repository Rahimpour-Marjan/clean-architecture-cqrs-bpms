using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class TicketAttachmentConfig : IEntityTypeConfiguration<TicketAttachment>
    {
        public void Configure(EntityTypeBuilder<TicketAttachment> builder)
        {
            builder.Property(f => f.Id).UseHiLo("TicketAttachment");

            builder.Property(f => f.TicketId).IsRequired();
            builder.Property(f => f.Title).IsRequired();
            builder.Property(f => f.FileUrl).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();
        }
    }
}
