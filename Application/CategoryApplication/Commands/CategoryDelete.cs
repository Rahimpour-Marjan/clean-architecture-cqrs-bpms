using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CategoryApplication.Commands
{
    public class CategoryDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CategoryId { get; set; }
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
                    await _uow.CategoryRepository.Delete(request.CategoryId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CategoryId = request.CategoryId
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
            public int CategoryId { get; set; }
        }
    }
}
