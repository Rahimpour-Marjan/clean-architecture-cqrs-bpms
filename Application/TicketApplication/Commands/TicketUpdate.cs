using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Ticket.Commands
{
    public class TicketUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int? TicketParentId { get; set; }
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
                var ticket = await _uow.TicketRepository.FindById(request.Id);
                if (ticket == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                ticket.Title = request.Title;
                ticket.TicketParentId = request.TicketParentId;
                ticket.TicketText = request.TicketText;
                ticket.TicketCreatorId = request.TicketCreatorId;
                ticket.TicketPriority = request.TicketPriority;
                ticket.TicketType = request.TicketType;

                try
                {
                    await _uow.TicketRepository.Update(ticket);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            TicketId = request.Id
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
