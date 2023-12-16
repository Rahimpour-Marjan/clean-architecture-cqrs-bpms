using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Calendar.Commands
{
    public class TicketAttachmentCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CalendarId { get; set; }
            public byte[] File { get; set; }
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
                var calendarAttachment = new Domain.CalendarAttachment(request.CalendarId, request.File);
                try
                {
                    var newCalendarAttachmentId = await _uow.CalendarRepository.Create(calendarAttachment);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CalendarAttachmentId = newCalendarAttachmentId
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
            public int CalendarAttachmentId { get; set; }
        }
    }
}
