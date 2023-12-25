using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCheckApplication.Commands
{
    public class AccountCheckCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountId { get; set; }
            public string CheckNumber { get; set; }
            public int BankId { get; set; }
            public string BranchName { get; set; }
            public long Amount { get; set; }
            public string PayTo { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ReceiptDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public string FrontImageUrl { get; set; }
            public string BackImageUrl { get; set; }
            public string? SignatureUrl { get; set; }
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
                var accountCheck = new AccountCheck(request.AccountId, request.CheckNumber, request.BankId, request.BranchName, request.Amount, request.PayTo, request.IssueDate, request.ReceiptDate, request.ReturnDate, request.FrontImageUrl, request.BackImageUrl, request.SignatureUrl, DateTime.Now);
                try
                {
                    var newAccountCheckId = await _uow.AccountCheckRepository.Create(accountCheck);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountCheckId = newAccountCheckId
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
