using Application.AccountCheckApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCheckApplication.Queries.FindById
{
    class FindAccountCheckByIdQueryHandler : IRequestHandler<FindAccountCheckByIdQuery, AccountCheckInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindAccountCheckByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<AccountCheckInfo> Handle(FindAccountCheckByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.AccountCheckRepository.FindById(request.Id);
            return _mapper.Map<Domain.AccountCheck, AccountCheckInfo>(model);
        }
    }
}
