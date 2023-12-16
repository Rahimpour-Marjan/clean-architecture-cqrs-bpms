using Domain.Resources;

namespace Domain
{
    public interface ITicketRepository
    {
        Task<int> Create(Ticket ticket);
        Task<int> Create(TicketAttachment ticketAttachment);
        Task<Tuple<IList<Ticket>, int>> FindAll(int userId,bool isAdmin,QueryFilter? queryFilter);
        Task<IList<Ticket>> FindAll(int UserId);
        Task<Ticket> FindParent(int id);
        Task<Ticket> FindById(int id);
        Task<string> GenerateCode(int? ticketParentId);
        Task Update(Ticket ticket);
        Task Delete(int id);
        Task DeleteAll(int[] ids);
    }
}
