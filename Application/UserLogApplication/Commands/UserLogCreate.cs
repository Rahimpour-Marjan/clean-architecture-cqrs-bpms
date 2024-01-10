using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserLogApplication.Commands
{
    public class UserLogCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public UserLogType Type { get; set; }
            public string IP { get; set; }
            public string Device { get; set; }
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
                var Unit = new Domain.UserLog(request.Type, request.IP, request.Device, request.CreatorId);
                try
                {
                    var newUserLogId = await _uow.UserLogRepository.Create(Unit);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            UserLogId = newUserLogId
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
            public int UserLogId { get; set; }
        }
    }
}
