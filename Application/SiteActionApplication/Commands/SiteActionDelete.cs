using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SiteActionApplication.Commands
{
    public class SiteActionDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int SiteActionId { get; set; }
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
                    await _uow.SiteActionRepository.Delete(request.SiteActionId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            SiteActionId = request.SiteActionId
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
            public int SiteActionId { get; set; }
        }
    }
}
