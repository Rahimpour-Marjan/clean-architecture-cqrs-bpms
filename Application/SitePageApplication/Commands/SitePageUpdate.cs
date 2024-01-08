using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.SitePage.Commands
{
    public class SitePageUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public int Priority { get; set; }
            public long MenuId { get; set; }
            public string Key { get; set; }
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
                var sitepage = await _uow.SitePageRepository.FindById(request.Id);
                if (sitepage == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                sitepage.Title = request.Title;
                sitepage.Url = request.Url;
                sitepage.Icon = request.Icon;
                sitepage.Priority = request.Priority;
                sitepage.MenuId = request.MenuId;
                sitepage.Key = request.Key;
                sitepage.ModifireId = request.ModifireId;
                sitepage.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.SitePageRepository.Update(sitepage);
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
