using Application.SiteActionApplication.Models;
using MediatR;

namespace Application.User.Queries.FindAccessById
{
    public class FindAccessByIdQuery : IRequest<IList<SiteActionInfo>?>
    {
        public int Id { get; set; }
    }
}
