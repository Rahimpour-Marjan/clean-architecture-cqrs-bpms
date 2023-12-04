using AutoMapper;
using MediatR;
using Application.QuickAccess.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance.Repositories;

namespace Application.QuickAccess.Queries.FindByKey
{
    public class FindQuickAccessByKeyQueryHandler : IRequestHandler<FindQuickAccessByKeyQuery, QuickAccessInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindQuickAccessByKeyQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<QuickAccessInfo> Handle(FindQuickAccessByKeyQuery request, CancellationToken cancellationToken)
        {
            var model =await _uow.QuickAccessRepository.FindByKey(request.Key,request.UserId);
            return _mapper.Map<Domain.QuickAccess, QuickAccessInfo>(model);
        }
    }
}