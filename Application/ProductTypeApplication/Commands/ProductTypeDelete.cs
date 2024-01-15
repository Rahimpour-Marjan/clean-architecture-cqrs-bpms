using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Commands
{
    public class ProductTypeDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductTypeId { get; set; }
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
                    await _uow.ProductTypeRepository.Delete(request.ProductTypeId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductTypeId = request.ProductTypeId
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
            public int ProductTypeId { get; set; }
        }
    }
}
