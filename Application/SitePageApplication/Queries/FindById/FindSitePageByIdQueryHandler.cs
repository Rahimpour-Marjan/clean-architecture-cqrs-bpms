using Application.SitePage.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SitePage.Queries.FindById
{
    internal class FindSitePageByIdQueryHandler : IRequestHandler<FindSitePageByIdQuery, SitePageInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindSitePageByIdQueryHandler(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<SitePageInfo> Handle(FindSitePageByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.SitePageRepository.FindById(request.Id);
            return _mapper.Map<Domain.SitePage, SitePageInfo>(model);
        }
    }
}
