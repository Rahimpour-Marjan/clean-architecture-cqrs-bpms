using Application.AccountCreditApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCreditApplication.Queries.FindById
{
    class FindAccountCreditByIdQueryHandler : IRequestHandler<FindAccountCreditByIdQuery, AccountCreditInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindAccountCreditByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<AccountCreditInfo> Handle(FindAccountCreditByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.AccountCreditRepository.FindById(request.Id);
            return _mapper.Map<Domain.AccountCredit, AccountCreditInfo>(model);
        }
    }
}
