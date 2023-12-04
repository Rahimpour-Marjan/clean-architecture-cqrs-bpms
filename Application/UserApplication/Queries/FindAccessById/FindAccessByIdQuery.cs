using MediatR;
using Application.SiteActionApplication.Models;

namespace Application.User.Queries.FindAccessById
{
    public class FindAccessByIdQuery : IRequest<IList<SiteActionInfo>?>
    {
        public int Id { get; set; }
    }
}
