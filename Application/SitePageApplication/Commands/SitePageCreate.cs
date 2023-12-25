using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.SitePage.Commands
{
    public class SitePageCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public int Priority { get; set; }
            public long MenuId { get; set; }
            public string Key { get; set; }
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
                var sitepage = new Domain.SitePage(request.Title, request.Url, request.Icon, request.Priority, request.MenuId, request.Key);
                try
                {
                    var newSitePageId = await _uow.SitePageRepository.Create(sitepage);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            SitePageId = newSitePageId
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
