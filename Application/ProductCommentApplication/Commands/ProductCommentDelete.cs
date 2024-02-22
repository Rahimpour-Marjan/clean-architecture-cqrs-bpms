using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCommentApplication.Commands
{
    public class ProductCommentDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductCommentId { get; set; }
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
                    await _uow.ProductCommentRepository.Delete(request.ProductCommentId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductCommentId = request.ProductCommentId
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
            public int ProductCommentId { get; set; }
        }
    }
}
