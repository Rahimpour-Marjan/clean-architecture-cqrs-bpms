using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.UserGroup.Commands
{
    public class UserGroupPrivilageCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int UserGroupId { get; set; }
            public int[] Ids { get; set; }
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
                    await _uow.UserGroupRepository.DeleteAllPrivilage(request.UserGroupId);

                    foreach (var item in request.Ids)
                    {
                        var siteAction = await _uow.SiteActionRepository.FindById(item);
                        var siteActionId = siteAction.Id;
                        var sitePageId = siteAction.SitePageId;
                        var sitePage = await _uow.SitePageRepository.FindById(sitePageId);
                        var menuId = sitePage.MenuId ?? 0;

                        var userGroupPrivilage = new Domain.UserGroupPrivilage(request.UserGroupId, menuId, sitePageId, siteActionId);

                        await _uow.UserGroupRepository.Create(userGroupPrivilage);
                    }

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
