using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SitePage.Commands
{
    public class SitePageDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public long Id { get; set; }
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
                    await _uow.SitePageRepository.Delete(request.Id);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            SitePageId = request.Id
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
            public long SitePageId { get; set; }
        }
    }
}
