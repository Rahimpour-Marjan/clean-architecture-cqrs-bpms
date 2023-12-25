using Application.UnitApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UnitApplication.Queries.FindById
{
    class FindUnitByIdQueryHandler : IRequestHandler<FindUnitByIdQuery, UnitInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindUnitByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UnitInfo> Handle(FindUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UnitRepository.FindById(request.Id);
            return _mapper.Map<Domain.Unit, UnitInfo>(model);
        }
    }
}
