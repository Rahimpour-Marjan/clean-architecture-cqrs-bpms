using Application.SiteActionApplication.Models;
using MediatR;

namespace Application.SiteActionApplication.Queries.FindById
{
    public class FindSiteActionByIdQuery : IRequest<SiteActionInfo>
    {
        public int Id { get; set; }
    }
}
