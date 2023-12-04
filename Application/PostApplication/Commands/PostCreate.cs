using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Post.Commands
{
    public class PostCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int? ParentId { get; set; }
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
                    var post = new Domain.Post(request.Title,request.ParentId);
                    var newPostId = await _uow.PostRepository.Create(post);
                   
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            postId = newPostId
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
            public int postId { get; set; }
        }
    }
}
