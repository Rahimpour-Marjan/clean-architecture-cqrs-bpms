using Application.Common;
using Application.Ticket.Models;
using Application.User.Queries.FindAccessById;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.Ticket.Queries.FindAll
{
    internal class FindAllTicketQueryHandler : IRequestHandler<FindAllTicketQuery, FindAllQueryResponse<IList<TicketInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;
        public FindAllTicketQueryHandler(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<FindAllQueryResponse<IList<TicketInfo>>> Handle(FindAllTicketQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                bool isAdmin = false;
                var userAccess = await _mediator.Send(new FindAccessByIdQuery { Id = request.UserId });
                if (userAccess != null && userAccess.Any())
                {
                    if (userAccess.Any(x => x.Controller == "TicketManagement"))
                        isAdmin = true;
                }

                if (!isAdmin && queryFilter.QueryFilterItem != null && queryFilter.QueryFilterItem.Any(x => x.ColumnName == "User"))
                    return FindAllQueryResponse<IList<TicketInfo>>.BuildFailure("شما مجوز دسترسی به این صفحه را ندارید.");

                var model = await _uow.TicketRepository.FindAll(request.UserId, isAdmin, queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Ticket, TicketInfo>).ToList();

                return FindAllQueryResponse<IList<TicketInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<TicketInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}

