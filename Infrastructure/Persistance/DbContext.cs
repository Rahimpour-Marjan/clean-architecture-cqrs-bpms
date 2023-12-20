using Microsoft.EntityFrameworkCore;
using Domain;
using System.Reflection;

namespace Infrastructure.Persistance
{
    public class MakmonDbContext : DbContext
    {
        public MakmonDbContext(DbContextOptions<MakmonDbContext> contextOptions)
        : base(contextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<EducationField> EducationFields { get; set; }
        public DbSet<EducationSubField> EducationSubFields { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AccountJuncPost> AccountJuncPost { get; set; }
        public DbSet<AccountAddress> AccountAddresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AccountCheck> AccountChecks { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<AccountCredit> AccountCredits { get; set; }
        public DbSet<CreditPayment> CreditPayments { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<SitePage> SitePage { get; set; }
        public DbSet<QuickAccess> QuickAccess { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<PostJuncUserGroup> PostJuncUserGroups { get; set; }
        public DbSet<UserGroupPrivilage> UserGroupPrivilages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAttachment> TicketAttachments { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarReceiver> CalendarReceivers { get; set; }
        public DbSet<CalendarAttachment> CalendarAttachments { get; set; }
        public DbSet<SiteAction> SiteActions { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                         .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                         .Where(type => type.BaseType != null &&
                                                        type.BaseType.IsGenericType &&
                                                        type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    builder.ApplyConfiguration(configurationInstance);
            //}
            foreach (var type in typesToRegister)
            {
                builder.HasSequence<int>(type.Namespace ?? "").StartsAt(1000).IncrementsBy(1);
            }
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasSequence<int>("CalendarAttachment").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Calendar").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("CalendarReceiver").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("SiteMenu").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Account").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Country").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("State").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("City").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Zone").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Package").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("EducationField").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("EducationSubField").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("EducationLevel").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Post").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("AccountAddress").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Bank").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("AccountCheck").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("CurrencyType").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("AccountCredit").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("CreditPayment").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("MyQuickAccess").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("SiteAction").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("MySitePage").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Ticket").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("TicketAttachment").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("Unit").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("User").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("UserGroup").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("UserGroupPrivilage").StartsAt(1000).IncrementsBy(1);
            builder.HasSequence<int>("UserLog").StartsAt(1000).IncrementsBy(1);

            base.OnModelCreating(builder);
        }

    }
}
