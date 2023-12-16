using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SiteActionApplication.Commands
{
    public class SiteActionUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int SiteActionId { get; set; }
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
                var siteAction = await _uow.SiteActionRepository.FindById(request.SiteActionId);
                if (siteAction == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                siteAction.Title = request.Title;
                siteAction.Controller = request.Controller;
                siteAction.Action = request.Action;
                siteAction.SitePageId = request.SitePageId;

                try
                {
                    await _uow.SiteActionRepository.Update(siteAction);
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
