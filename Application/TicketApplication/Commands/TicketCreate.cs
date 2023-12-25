using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Ticket.Commands
{
    public class TicketCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int? TicketParentId { get; set; }
            public int? WorkRequestId { get; set; }
            public string TicketText { get; set; }
            public int TicketCreatorId { get; set; }
            public TicketStatus Status { get; set; }
            public TicketPriority TicketPriority { get; set; }
            public TicketType TicketType { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.TicketParentId != null)
                {
                    var ticketParent = await _uow.TicketRepository.FindById(request.TicketParentId ?? 0);
                    if (ticketParent != null)
                    {
                        ticketParent.Status = request.Status;
                        await _uow.TicketRepository.Update(ticketParent);
                    }
                }

                var code = await _uow.TicketRepository.GenerateCode(request.TicketParentId);

                var ticket = new Domain.Ticket(request.Title, code, request.TicketParentId, request.TicketText, request.TicketCreatorId, request.WorkRequestId, request.Status, request.TicketPriority, request.TicketType);

                try
                {
                    var newTicketId = await _uow.TicketRepository.Create(ticket);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            TicketId = newTicketId
                        });
                    await Task.CompletedTask;
                    return result;
                }
                catch (Exception ex)
                {
                    var exResult = OperationResult<Response>.BuildFailure(ex);
                    return exResult;
                }
            }
        }

        public class Response
        {
            public int TicketId { get; set; }
        }
    }
}
