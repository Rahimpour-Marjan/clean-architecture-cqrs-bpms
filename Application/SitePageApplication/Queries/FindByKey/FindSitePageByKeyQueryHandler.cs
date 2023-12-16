using AutoMapper;
using MediatR;
using Application.SitePage.Models;
using Application.SitePage.Queries.FindByKey;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance.Repositories;

namespace Application.QuickAccess.Queries.FindById
{
    public class FindSitePageByKeyQueryHandler : IRequestHandler<FindSitePageByKeyQuery, SitePageInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindSitePageByKeyQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<SitePageInfo> Handle(FindSitePageByKeyQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.SitePageRepository.FindByKey(request.Key);
            return _mapper.Map<Domain.SitePage, SitePageInfo>(model);
        }
    }
}
