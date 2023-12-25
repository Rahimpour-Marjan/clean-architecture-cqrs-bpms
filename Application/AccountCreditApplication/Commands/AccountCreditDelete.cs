using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCreditApplication.Commands
{
    public class AccountCreditDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountCreditId { get; set; }
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
                    await _uow.AccountCreditRepository.Delete(request.AccountCreditId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountCreditId = request.AccountCreditId
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
            public int AccountCreditId { get; set; }
        }
    }
}
