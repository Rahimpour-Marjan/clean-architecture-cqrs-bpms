using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configs
{
    public class AccountCheckConfig : IEntityTypeConfiguration<AccountCheck>
    {
        public void Configure(EntityTypeBuilder<AccountCheck> builder)
        {
            builder.Property(f => f.Id).UseHiLo("AccountCheck");

            builder.Property(f => f.AccountId).IsRequired();
            builder.Property(f => f.CheckNumber).HasMaxLength(10).IsRequired();
            builder.HasIndex(f => f.CheckNumber).IsUnique();
            builder.Property(f => f.BankId).IsRequired();
            builder.Property(f => f.BranchName).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Amount).IsRequired();
            builder.Property(f => f.PayTo).HasMaxLength(100).IsRequired();
            builder.Property(f => f.IssueDate).IsRequired();
            builder.Property(f => f.IssueDate).IsRequired();
            builder.Property(f => f.ReceiptDate).HasMaxLength(100);
            builder.Property(f => f.FrontImageUrl).HasMaxLength(100).IsRequired();
            builder.Property(f => f.BackImageUrl).HasMaxLength(100).IsRequired();
            builder.Property(f => f.CreatorId).IsRequired();
            builder.Property(f => f.CreateDate).IsRequired();

            builder.HasOne(x => x.Account)
             .WithMany(x => x.AccountChecks)
             .HasForeignKey(x => x.AccountId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Bank)
             .WithMany()
             .HasForeignKey(x => x.BankId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
