using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserGroup.Commands
{
    public class UserGroupCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public bool IsEditable { get; set; }
            public int? UserGroupParentId { get; set; }
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

                var usergroup = new Domain.UserGroup(request.Title, request.IsActive,request.IsEditable, request.UserGroupParentId, request.CreatorId);
                try
                {
                    var newUserGroupId = await _uow.UserGroupRepository.Create(usergroup);
                    var result = OperationResult<Response>
                    .BuildSuccessResult(new Response
                    {
                        UserGroupId = 0
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
            public long UserGroupId { get; set; }
        }
    }
}
