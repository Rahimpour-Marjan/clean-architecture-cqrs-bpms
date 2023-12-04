using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.QuickAccess.Commands
{
    public class QuickAccessDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string key { get; set; }
            public int UserId { get; set; }
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
                    await _uow.QuickAccessRepository.Delete(request.key, request.UserId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {

                            QuickAccessKey = request.key
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
            public string QuickAccessKey { get; set; }
        }
    }
}