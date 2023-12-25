using Application.Common;
using Domain;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCreditApplication.Commands
{
    public class AccountCreditCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountId { get; set; }
            public string? Description { get; set; }
            public long Amount { get; set; }
            public long Remain { get; set; }
            public int? AccountCheckId { get; set; }
            public bool IsActive { get; set; }
            public CreditType CreditType { get; set; }
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
                var accountCredit = new AccountCredit(request.AccountId, request.Description, request.Amount, request.Remain, request.AccountCheckId, request.IsActive, request.CreditType, DateTime.Now);
                try
                {
                    var newAccountCreditId = await _uow.AccountCreditRepository.Create(accountCredit);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountCreditId = newAccountCreditId
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
