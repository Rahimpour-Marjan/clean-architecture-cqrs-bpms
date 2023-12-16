using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserGroup.Commands
{
    public class UserGroupDeleteAll
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
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
                    var deleteIds = new List<int>();
                    foreach (var item in request.Ids)
                    {
                        var usergroup = await _uow.UserGroupRepository.FindById(item);
                        if (usergroup != null && usergroup.IsEditable == true)
                            deleteIds.Add(item);
                    }
                    await _uow.UserGroupRepository.DeleteAll(deleteIds.ToArray());
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
