using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.PersonAddressApplication.Models;

namespace Application.PersonAddressApplication.Queries.FindById
{
    class FindPersonAddressByIdQueryHandler : IRequestHandler<FindPersonAddressByIdQuery, PersonAddressInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindPersonAddressByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PersonAddressInfo> Handle(FindPersonAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.PersonAddressRepository.FindById(request.Id);
            return _mapper.Map<Domain.PersonAddress, PersonAddressInfo>(model);
        }
    }
}
