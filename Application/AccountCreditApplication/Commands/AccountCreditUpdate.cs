using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCreditApplication.Commands
{
    public class AccountCreditUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountCreditId { get; set; }
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
                var accountCredit = await _uow.AccountCreditRepository.FindById(request.AccountCreditId);
                if (accountCredit == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                accountCredit.AccountId = request.AccountId;
                accountCredit.Description = request.Description;
                accountCredit.Amount = request.Amount;
                accountCredit.Remain = request.Remain;
                accountCredit.Amount = request.Amount;
                accountCredit.AccountCheckId = request.AccountCheckId;
                accountCredit.IsActive = request.IsActive;
                accountCredit.CreditType = request.CreditType;
                accountCredit.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.AccountCreditRepository.Update(accountCredit);
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
