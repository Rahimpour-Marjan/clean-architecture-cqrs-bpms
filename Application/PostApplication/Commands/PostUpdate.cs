using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Post.Commands
{
    public class PostUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int? PostParentId { get; set; }
            public int ModifireId { get; set; }

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
                    var post = await _uow.PostRepository.FindById(request.Id);
                    if (post == null)
                        return OperationResult<Response>.BuildFailure("سمتی جهت ویرایش یافت نشد!");
                    else if (post.Id == request.PostParentId)
                        return OperationResult<Response>.BuildFailure("سمت والد نمیتواند، با سمت فعلی یکسان باشد.");
                    post.Title = request.Title;
                    post.PostParentId = request.PostParentId;
                    post.ModifireId = request.ModifireId;
                    post.ModifiedDate = DateTime.Now;

                    await _uow.PostRepository.Update(post);

                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PostId = request.Id
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
