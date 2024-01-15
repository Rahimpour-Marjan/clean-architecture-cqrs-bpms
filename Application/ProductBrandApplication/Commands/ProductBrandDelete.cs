using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductBrandApplication.Commands
{
    public class ProductBrandDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductBrandId { get; set; }
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
                    await _uow.ProductBrandRepository.Delete(request.ProductBrandId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductBrandId = request.ProductBrandId
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
            public int ProductBrandId { get; set; }
        }
    }
}
