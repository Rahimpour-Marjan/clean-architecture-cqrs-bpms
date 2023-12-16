using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SiteActionApplication.Commands
{
    public class SiteActionCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public long SitePageId { get; set; }
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
                var siteAction = new SiteAction(request.Title, request.Controller, request.Action, request.SitePageId);
                try
                {
                    var newSiteActionId = await _uow.SiteActionRepository.Create(siteAction);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            SiteActionId = newSiteActionId
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
