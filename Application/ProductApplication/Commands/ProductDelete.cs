using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductApplication.Commands
{
    public class ProductDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductId { get; set; }
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
                    await _uow.ProductRepository.Delete(request.ProductId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductId = request.ProductId
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
            public int ProductId { get; set; }
        }
    }
}
