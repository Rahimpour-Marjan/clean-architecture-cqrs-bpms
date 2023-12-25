using Application.Calendar.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Calendar.Queries.FindById
{
    internal class FindStoreByIdQueryHandler : IRequestHandler<FindCalendarByIdQuery, CalendarInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindStoreByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CalendarInfo> Handle(FindCalendarByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CalendarRepository.FindById(request.Id);
            return _mapper.Map<Domain.Calendar, CalendarInfo>(model);
        }
    }
}

