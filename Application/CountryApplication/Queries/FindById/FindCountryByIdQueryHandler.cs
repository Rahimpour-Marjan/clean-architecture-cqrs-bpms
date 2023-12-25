using Application.CountryApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CountryApplication.Queries.FindById
{
    class FindCountryByIdQueryHandler : IRequestHandler<FindCountryByIdQuery, CountryInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindCountryByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CountryInfo> Handle(FindCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CountryRepository.FindById(request.Id);
            return _mapper.Map<Domain.Country, CountryInfo>(model);
        }
    }
}
