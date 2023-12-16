using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Notification.Commands
{
    public class NotificationCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string Text { get; set; }
            public int? SenderId { get; set; }
            public int ReceiverId { get; set; }
            public string Icon { get; set; }
            public string Link { get; set; }
            public bool IsRead { get; set; }
            public bool IsStar { get; set; }
            public bool IsArchive { get; set; }
            public bool IsDeleted { get; set; }
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
                var notification = new Domain.Notification(request.Title, request.Text, request.SenderId, request.ReceiverId, request.Icon, request.Link,request.IsRead, request.IsStar,request.IsArchive,request.IsDeleted);
                try
                {
                    var newNotificationId = await _uow.NotificationRepository.Create(notification);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            NotificationId = newNotificationId
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
            public int NotificationId { get; set; }
        }
    }
}
