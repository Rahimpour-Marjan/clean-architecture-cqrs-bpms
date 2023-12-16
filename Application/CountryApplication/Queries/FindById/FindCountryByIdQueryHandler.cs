using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.CountryApplication.Models;

namespace Application.CountryApplication.Queries.FindById
{
    class FindUnitByIdQueryHandler : IRequestHandler<FindCountryByIdQuery, CountryInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindUnitByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
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
