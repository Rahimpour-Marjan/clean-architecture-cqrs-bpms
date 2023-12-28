using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class AccountCreditConfig : IEntityTypeConfiguration<AccountCredit>
    {
        public void Configure(EntityTypeBuilder<AccountCredit> builder)
        {
            builder.Property(f => f.Id).UseHiLo("AccountCredit");

            builder.Property(f => f.AccountId).IsRequired();
            builder.Property(f => f.Description).HasMaxLength(400);
            builder.Property(f => f.Amount).IsRequired();
            builder.Property(f => f.Remain).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.CreditType).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Account)
             .WithMany(x => x.AccountCredits)
             .HasForeignKey(x => x.AccountId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AccountCheck)
             .WithMany()
             .HasForeignKey(x => x.AccountCheckId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
