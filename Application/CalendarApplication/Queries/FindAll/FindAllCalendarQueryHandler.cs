using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using Application.Calendar.Models;
using Domain;
using Infrastructure.Persistance.Repositories;

namespace Application.Calendar.Queries.FindAll
{
    internal class FindAllStoreQueryHandler : IRequestHandler<FindAllCalendarQuery, IList<CalendarInfo>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllStoreQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IList<CalendarInfo>> Handle(FindAllCalendarQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.CalendarRepository.FindAll();
            return model.Select(_mapper.Map<Domain.Calendar, CalendarInfo>).ToList();
        }
    }
}

