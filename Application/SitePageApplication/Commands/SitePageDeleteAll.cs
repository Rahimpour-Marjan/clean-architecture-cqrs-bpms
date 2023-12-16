using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SitePage.Commands
{
    public class SitePageDeleteAll
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public long[] Ids { get; set; }
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
                    await _uow.SitePageRepository.DeleteAll(request.Ids);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            Result = true
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
            public bool Result { get; set; }
        }
    }
}
