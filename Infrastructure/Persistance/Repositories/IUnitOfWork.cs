using Domain;

namespace Infrastructure.Persistance.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUnitRepository UnitRepository { get; }
        IAccountRepository AccountRepository { get; }
        ICountryRepository CountryRepository { get; }
        IStateRepository StateRepository { get; }
        ICityRepository CityRepository { get; }
        IZoneRepository ZoneRepository { get; }
        IPackageRepository PackageRepository { get; }
        IEducationFieldRepository EducationFieldRepository { get; }
        IEducationSubFieldRepository EducationSubFieldRepository { get; }
        IEducationLevelRepository EducationLevelRepository { get; }
        IPostRepository PostRepository { get; }
        IAccountAddressRepository AccountAddressRepository { get; }
        IBankRepository BankRepository { get; }
        IAccountCheckRepository AccountCheckRepository { get; }
        ICurrencyTypeRepository CurrencyTypeRepository { get; }
        IAccountCreditRepository AccountCreditRepository { get; }
        ICreditPaymentRepository CreditPaymentRepository { get; }
        IMenuRepository MenuRepository { get; }
        ISitePageRepository SitePageRepository { get; }
        IQuickAccessRepository QuickAccessRepository { get; }
        IUserGroupRepository UserGroupRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ITicketRepository TicketRepository { get; }
        ICalendarRepository CalendarRepository { get; }
        ISiteActionRepository SiteActionRepository { get; }
        IUserLogRepository UserLogRepository { get; }
        Task<bool> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakmonDbContext _db;
        public UnitOfWork(MakmonDbContext db)
        {
            _db = db;
            UserRepository = new UserRepository(_db);
            UnitRepository = new UnitRepository(_db);
            AccountRepository = new AccountRepository(_db);
            CountryRepository = new CountryRepository(_db);
            StateRepository = new StateRepository(_db);
            CityRepository = new CityRepository(_db);
            ZoneRepository = new ZoneRepository(_db);
            PackageRepository = new PackageRepository(_db);
            EducationFieldRepository = new EducationFieldRepository(_db);
            EducationSubFieldRepository = new EducationSubFieldRepository(_db);
            EducationLevelRepository = new EducationLevelRepository(_db);
            PostRepository = new PostRepository(_db);
            AccountAddressRepository = new AccountAddressRepository(_db);
            BankRepository = new BankRepository(_db);
            AccountCheckRepository = new AccountCheckRepository(_db);
            CurrencyTypeRepository = new CurrencyTypeRepository(_db);
            AccountCreditRepository = new AccountCreditRepository(_db);
            CreditPaymentRepository = new CreditPaymentRepository(_db);
            MenuRepository = new MenuRepository(_db);
            SitePageRepository = new SitePageRepository(_db);
            QuickAccessRepository = new QuickAccessRepository(_db);
            UserGroupRepository = new UserGroupRepository(_db);
            NotificationRepository = new NotificationRepository(_db);
            TicketRepository = new TicketRepository(_db);
            CalendarRepository = new CalendarRepository(_db);
            SiteActionRepository = new SiteActionRepository(_db);
            UserLogRepository = new UserLogRepository(_db);
        }

        public IUserRepository UserRepository { get; }
        public IUnitRepository UnitRepository { get; }
        public IAccountRepository AccountRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IStateRepository StateRepository { get; }
        public ICityRepository CityRepository { get; }
        public IZoneRepository ZoneRepository { get; }
        public IPackageRepository PackageRepository { get; }
        public IEducationFieldRepository EducationFieldRepository { get; }
        public IEducationSubFieldRepository EducationSubFieldRepository { get; }
        public IEducationLevelRepository EducationLevelRepository { get; }
        public IPostRepository PostRepository { get; }
        public IAccountAddressRepository AccountAddressRepository { get; }
        public IBankRepository BankRepository { get; }
        public IAccountCheckRepository AccountCheckRepository { get; }
        public ICurrencyTypeRepository CurrencyTypeRepository { get; }
        public IAccountCreditRepository AccountCreditRepository { get; }
        public ICreditPaymentRepository CreditPaymentRepository { get; }
        public IMenuRepository MenuRepository { get; }
        public ISitePageRepository SitePageRepository { get; }
        public IQuickAccessRepository QuickAccessRepository { get; }
        public IUserGroupRepository UserGroupRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public ITicketRepository TicketRepository { get; }
        public ICalendarRepository CalendarRepository { get; }
        public ISiteActionRepository SiteActionRepository { get; }
        public IUserLogRepository UserLogRepository { get; }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
