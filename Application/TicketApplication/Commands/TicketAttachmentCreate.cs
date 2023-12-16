using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Ticket.Commands
{
    public class TicketAttachmentCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string FileUrl { get; set; }
            public decimal? Size { get; set; }
            public int TicketId { get; set; }
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
                var ticketattachemt = new Domain.TicketAttachment(request.FileUrl, request.Title, request.Size, request.TicketId);
                try
                {
                    var newTicketAttachmentId = await _uow.TicketRepository.Create(ticketattachemt);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            TicketAttachmentId = newTicketAttachmentId
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
            public int TicketAttachmentId { get; set; }
        }
    }
}
