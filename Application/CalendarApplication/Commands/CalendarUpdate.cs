using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Calendar.Commands
{
    public class CalendarUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Description { get; set; }
            public string EventDate { get; set; }
            public string EventTime { get; set; }
            //public int SenderId { get; set; }
            public string? NotificationDate { get; set; }
            public string? NotificationTime { get; set; }
            public bool? HasTwoStepNotification { get; set; }
            public int[] ReceiversId { get; set; }

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
                var calendar = await _uow.CalendarRepository.FindById(request.Id);
                if (calendar == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                calendar.Subject = request.Subject;
                calendar.Description = request.Description;
                calendar.EventDate = request.EventDate;
                calendar.EventTime = request.EventTime;
                //calendar.SenderId = request.SenderId;
                calendar.NotificationDate = request.NotificationDate;
                calendar.NotificationTime = request.NotificationTime;
                calendar.HasTwoStepNotification = request.HasTwoStepNotification;
                try
                {
                    await _uow.CalendarRepository.Update(calendar);
                    await _uow.CalendarRepository.CalendarRecevierDelete(request.Id);
                    await _uow.CalendarRepository.Create(request.ReceiversId, request.Id);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CalendarId = request.Id
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
