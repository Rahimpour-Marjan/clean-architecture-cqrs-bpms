using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Notification.Commands
{
    public class NotificationIsArchiveUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public bool IsArchive { get; set; }
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
                var notification = await _uow.NotificationRepository.FindById(request.Id, request.UserId);
                if (notification == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                notification.IsArchive = request.IsArchive;
                notification.ModifireId = request.ModifireId;
                notification.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.NotificationRepository.Update(notification);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            NotificationId = request.Id
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
