using Domain;
using Domain.Resources;
using Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MakmonDbContext _db;
        public TicketRepository(MakmonDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(Ticket ticket)
        {
            var result = _db.Tickets.Add(ticket);
            return result.Entity.Id;
        }
        public async Task<int> Create(TicketAttachment ticketAttachment)
        {
            var result = _db.TicketAttachments.Add(ticketAttachment);
            return result.Entity.Id;
        }

        public async Task<Ticket> FindParent(int id)
        {
            return await _db.Tickets.Include(x=>x.TicketCreator).Include(x=>x.TicketChilds).Include(t => t.TicketAttachments).Where(t => t.Id == id && t.TicketParentId==null).FirstOrDefaultAsync();
        }
        public async Task<string> GenerateCode(int? ticketParentId)
        {
            if (ticketParentId != null)
            {
                var ticket = await _db.Tickets.FirstOrDefaultAsync(x => x.Id == ticketParentId);
                if (ticket != null)
                    return ticket.Code;
            }
                
            var lastItem = await _db.Tickets.Where(x => x.Code != null && x.TicketParentId == null).OrderByDescending(x => x.TicketCreateDate).FirstOrDefaultAsync();
            var code = "100000";
            if (lastItem != null)
            {
                if (lastItem.Code != null)
                {
                    code = (Convert.ToInt32(lastItem.Code) + 1).ToString();
                }
            }
            return $"{code}";
        }
        public async Task<Ticket> FindById(int id)
        {
            return await _db.Tickets.Include(x => x.TicketCreator).ThenInclude(x=>x.Person).Include(x => x.TicketAttachments)
                .Include(x => x.TicketChilds).ThenInclude(x=>x.TicketAttachments)
                .Include(x => x.TicketChilds).ThenInclude(x=>x.TicketCreator).ThenInclude(x=>x.Person).OrderBy(x => x.TicketCreateDate)
                .FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<Tuple<IList<Ticket>, int>> FindAll(int userId,bool isAdmin, QueryFilter? queryFilter)
        {
            var query = _db.Tickets.Include(x => x.TicketCreator).ThenInclude(x=>x.Person).Include(x => x.TicketAttachments)
                .Include(x => x.TicketChilds).ThenInclude(x=>x.TicketAttachments)
                .Include(x => x.TicketChilds).ThenInclude(x=>x.TicketCreator).ThenInclude(x=>x.Person)
                .Where(x=>(isAdmin == true || x.TicketCreatorId == userId) && x.TicketParentId == null).OrderBy(x=>x.TicketCreateDate)
                .AsQueryable();

            query = query.ApplyFiltering(queryFilter);

            var totalRecords = query.Count();

            query = query.ApplyOrdering(queryFilter, "Entity");

            query = query.ApplyPaging(queryFilter);

            return new Tuple<IList<Ticket>, int>(await query.ToListAsync(), totalRecords);
        }
        public async Task<IList<Ticket>> FindAll(int UserId)
        {
            return await _db.Tickets
                        .Where(t => t.TicketCreatorId == UserId)
                        .Include(t=>t.TicketAttachments).Include(x => x.TicketChilds).Include(x => x.TicketCreator).ThenInclude(x=>x.Person)
                        .ToListAsync();
        }
        public async Task Update(Ticket ticket)
        {
            _db.Entry((Ticket)ticket).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            var ticket = await FindById(id);
            _db.Entry((Ticket)ticket).State = EntityState.Deleted;
        }
        public async Task DeleteAll(int[] ids)
        {
            var ticket = await _db.Tickets.Where(x => ids.Contains(x.Id)).ToListAsync();
            _db. Tickets.RemoveRange(ticket);
        }
    }
}
