using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;
namespace Application.Notification.Commands
{
    public class NotificationDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public int? UserId { get; set; }
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
                    await _uow.NotificationRepository.Delete(request.Id,request.UserId);
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
