using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Calendar.Commands
{
    public class CalendarCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Subject { get; set; }
            public string Description { get; set; }
            public string EventDate { get; set; }
            public string EventTime { get; set; }
            public int SenderId { get; set; }
            public string? NotificationDate { get; set; }
            public string? NotificationTime { get; set; }
            public bool? HasTwoStepNotification { get; set; }
            public int[] ReceiversId { get; set; }
            public int CreatorId { get; set; }
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
                var calendar = new Domain.Calendar(request.Subject, request.Description, request.EventDate, request.EventTime, request.SenderId, request.NotificationDate, request.NotificationTime, request.HasTwoStepNotification,request.CreatorId);
                try
                {
                    var newCalendarId = await _uow.CalendarRepository.Create(calendar);
                    await _uow.CalendarRepository.Create(request.ReceiversId, newCalendarId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CalendarId = newCalendarId
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
            public int CalendarId { get; set; }
        }
    }
}
