using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCheckApplication.Commands
{
    public class AccountCheckDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountCheckId { get; set; }
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
                    await _uow.AccountCheckRepository.Delete(request.AccountCheckId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountCheckId = request.AccountCheckId
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
            public int AccountCheckId { get; set; }
        }
    }
}
