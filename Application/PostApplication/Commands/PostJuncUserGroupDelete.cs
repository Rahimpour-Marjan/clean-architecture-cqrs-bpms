using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Post.Commands
{
    public class PostJuncUserGroupDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PostId { get; set; }
            public int[] UserGroupIds { get; set; }
        }
        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            private readonly IMediator _mediator;
            public Handler(IUnitOfWork uow, IMediator mediator)
            {
                _uow = uow;
                _mediator = mediator;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {

                    await _uow.PostRepository.PostJuncUserGroupDelete(request.PostId, request.UserGroupIds);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PostId = request.PostId
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
            public int PostId { get; set; }
        }
    }
}
