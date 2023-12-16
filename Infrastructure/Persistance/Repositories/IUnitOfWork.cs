using Domain;

namespace Infrastructure.Persistance.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUnitRepository UnitRepository { get; }
        IPostRepository PostRepository { get; }
        IPersonRepository PersonRepository { get; }
        ICountryRepository CountryRepository { get; }
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
            PostRepository = new PostRepository(_db);
            PersonRepository = new PersonRepository(_db);
            CountryRepository = new CountryRepository(_db);
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
        public IPostRepository PostRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public ICountryRepository CountryRepository { get; }
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
