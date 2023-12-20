using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCheckApplication.Commands
{
    public class AccountCheckUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountCheckId { get; set; }
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
                var accountCheck = await _uow.AccountCheckRepository.FindById(request.AccountCheckId);
                if (accountCheck == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                accountCheck.AccountId = request.AccountId;
                accountCheck.CheckNumber = request.CheckNumber;
                accountCheck.BankId = request.BankId;
                accountCheck.BranchName = request.BranchName;
                accountCheck.Amount = request.Amount;
                accountCheck.PayTo = request.PayTo;
                accountCheck.IssueDate = request.IssueDate;
                accountCheck.ReceiptDate = request.ReceiptDate;
                accountCheck.ReturnDate = request.ReturnDate;
                accountCheck.FrontImageUrl = request.FrontImageUrl;
                accountCheck.BackImageUrl = request.BackImageUrl;
                accountCheck.SignatureUrl = request.SignatureUrl;
                accountCheck.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.AccountCheckRepository.Update(accountCheck);
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
