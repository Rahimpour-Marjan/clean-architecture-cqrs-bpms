using Application.ZoneApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ZoneApplication.Queries.FindById
{
    class FindZoneByIdQueryHandler : IRequestHandler<FindZoneByIdQuery, ZoneInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindZoneByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ZoneInfo> Handle(FindZoneByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ZoneRepository.FindById(request.Id);
            return _mapper.Map<Domain.Zone, ZoneInfo>(model);
        }
    }
}
