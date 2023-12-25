using Application.QuickAccess.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.QuickAccess.Queries.FindById
{
    public class FindQuickAccessByIdQueryHandler : IRequestHandler<FindQuickAccessByIdQuery, QuickAccessInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindQuickAccessByIdQueryHandler(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<QuickAccessInfo> Handle(FindQuickAccessByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.QuickAccessRepository.FindById(request.Id, request.UserId);
            return _mapper.Map<Domain.QuickAccess, QuickAccessInfo>(model);
        }
    }
}
