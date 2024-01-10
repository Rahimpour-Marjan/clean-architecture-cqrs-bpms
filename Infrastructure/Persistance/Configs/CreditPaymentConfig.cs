using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class CreditPaymentConfig : IEntityTypeConfiguration<CreditPayment>
    {
        public void Configure(EntityTypeBuilder<CreditPayment> builder)
        {
            builder.Property(f => f.Id).UseHiLo("CreditPayment");

            builder.Property(f => f.AccountId).IsRequired();
            builder.Property(f => f.AccountCreditId).IsRequired();
            builder.Property(f => f.Status).IsRequired();
            builder.Property(f => f.RefNumber).HasMaxLength(30);
            builder.HasIndex(f => f.RefNumber).IsUnique();
            builder.Property(f => f.ExternalInfo1).HasMaxLength(100);
            builder.Property(f => f.ExternalInfo2).HasMaxLength(100);
            builder.Property(f => f.Amount).IsRequired();
            builder.Property(f => f.IpAddress).HasMaxLength(20).IsRequired();
            builder.Property(f => f.Description).HasMaxLength(400);
            builder.Property(f => f.CurrencyTypeId).IsRequired();
            builder.Property(f => f.IsInPlace).IsRequired();
            builder.Property(f => f.ImageUrl).HasMaxLength(100);
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Account)
             .WithMany(x => x.CreditPayments)
             .HasForeignKey(x => x.AccountId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AccountCredit)
            .WithMany(x => x.CreditPayments)
            .HasForeignKey(x => x.AccountCreditId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CurrencyType)
           .WithMany()
           .HasForeignKey(x => x.CurrencyTypeId)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
