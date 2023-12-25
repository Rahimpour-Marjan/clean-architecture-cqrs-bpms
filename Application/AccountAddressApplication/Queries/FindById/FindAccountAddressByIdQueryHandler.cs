using Application.AccountAddressApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountAddressApplication.Queries.FindById
{
    class FindAccountAddressByIdQueryHandler : IRequestHandler<FindAccountAddressByIdQuery, AccountAddressInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindAccountAddressByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<AccountAddressInfo> Handle(FindAccountAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.AccountAddressRepository.FindById(request.Id);
            return _mapper.Map<Domain.AccountAddress, AccountAddressInfo>(model);
        }
    }
}
