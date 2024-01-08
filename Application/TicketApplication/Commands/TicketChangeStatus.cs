using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Ticket.Commands
{
    public class TicketChangeStatus
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public TicketStatus Status { get; set; }
            public int UserId { get; set; }
            public int ModifireId { get; set; }
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
                try
                {
                    var ticket = await _uow.TicketRepository.FindParent(request.Id);
                    ticket.Status = request.Status;
                    ticket.ModifireId = request.ModifireId;
                    ticket.ModifiedDate = DateTime.Now;

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
