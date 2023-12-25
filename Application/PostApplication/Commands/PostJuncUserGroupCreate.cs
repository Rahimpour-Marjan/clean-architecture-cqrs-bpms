using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Post.Commands
{
    public class PostJuncUserGroupCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PostId { get; set; }
            public int[] UserGroupIds { get; set; }
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
                    for (int i = 0; i < request.UserGroupIds.Length; i++)
                    {
                        var post = new Domain.PostJuncUserGroup(request.PostId, request.UserGroupIds[i], false);
                        await _uow.PostRepository.Create(post);

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
