using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(f => f.Id).UseHiLo("Ticket");

            builder.Property(f => f.Title).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Code).IsRequired();
            builder.Property(f => f.TicketText).IsRequired();
            builder.Property(f => f.TicketCreatorId).IsRequired();
            builder.Property(f => f.TicketPriority).IsRequired();
            builder.Property(f => f.TicketType).IsRequired();
            builder.Property(f => f.Status).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.TicketCreator)
                      .WithMany(x => x.Tickets)
                      .HasForeignKey(x => x.TicketCreatorId)
                      .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.TicketParent)
                  .WithMany(x => x.TicketChilds)
                  .HasForeignKey(x => x.TicketParentId)
                  .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
