using MediatR;
using Application.SiteActionApplication.Models;

namespace Application.SiteActionApplication.Queries.FindById
{
    public class FindSiteActionByIdQuery : IRequest<SiteActionInfo>
    {
        public int Id { get; set; }
    }
}
