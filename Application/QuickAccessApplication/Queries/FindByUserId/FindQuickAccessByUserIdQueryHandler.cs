using Application.QuickAccess.Models;
using Application.QuickAccess.Queries.FindByUserId;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.QuickAccess.Queries.FindById
{
    public class FindQuickAccessByUserIdQueryHandler : IRequestHandler<FindQuickAccessByUserIdQuery, IList<QuickAccessInfo>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindQuickAccessByUserIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IList<QuickAccessInfo>> Handle(FindQuickAccessByUserIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.QuickAccessRepository.FindByUserId(request.UserId);
            return model.Select(_mapper.Map<Domain.QuickAccess, QuickAccessInfo>).ToList();

        }
    }
}
