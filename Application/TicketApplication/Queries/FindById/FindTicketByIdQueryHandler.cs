using AutoMapper;
using MediatR;
using Application.Ticket.Models;
using Infrastructure.Persistance.Repositories;

namespace Application.Ticket.Queries.FindById
{
    internal class FindTicketByIdQueryHandler : IRequestHandler<FindTicketByIdQuery, TicketInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindTicketByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<TicketInfo> Handle(FindTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.TicketRepository.FindById(request.Id); 
            return _mapper.Map<Domain.Ticket, TicketInfo>(model);
        }
    }
}

