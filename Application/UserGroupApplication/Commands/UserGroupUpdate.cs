using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserGroup.Commands
{
    public class UserGroupUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public bool IsEditable { get; set; }
            public int? UserGroupParentId { get; set; }
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
                var usergroup = await _uow.UserGroupRepository.FindById(request.Id);
                if (usergroup == null || usergroup.IsEditable == false)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                usergroup.Title = request.Title;
                usergroup.IsActive = request.IsActive;
                usergroup.IsEditable = request.IsEditable;
                usergroup.UserGroupParentId = request.UserGroupParentId;
                try
                {
                    await _uow.UserGroupRepository.Update(usergroup);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            UserGroupId = request.Id
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
