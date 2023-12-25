using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.CityApplication.Models;

namespace Application.CityApplication.Queries.FindById
{
    class FindCityByIdQueryHandler : IRequestHandler<FindCityByIdQuery, CityInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindCityByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CityInfo> Handle(FindCityByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CityRepository.FindById(request.Id);
            return _mapper.Map<Domain.City, CityInfo>(model);
        }
    }
}
