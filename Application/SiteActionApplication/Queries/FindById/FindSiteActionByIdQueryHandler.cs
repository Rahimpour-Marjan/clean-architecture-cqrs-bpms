using AutoMapper;
using MediatR;
using Domain;
using Infrastructure.Persistance.Repositories;
using Application.SiteActionApplication.Models;

namespace Application.SiteActionApplication.Queries.FindById
{
    class FindSiteActionByIdQueryHandler : IRequestHandler<FindSiteActionByIdQuery, SiteActionInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindSiteActionByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<SiteActionInfo> Handle(FindSiteActionByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.SiteActionRepository.FindById(request.Id);
            return _mapper.Map<SiteAction, SiteActionInfo>(model);
        }
    }
}
