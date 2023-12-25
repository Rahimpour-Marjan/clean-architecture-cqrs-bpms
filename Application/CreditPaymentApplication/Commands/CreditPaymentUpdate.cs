using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CreditPaymentApplication.Commands
{
    public class CreditPaymentUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CreditPaymentId { get; set; }
            public int AccountId { get; set; }
            public int AccountCreditId { get; set; }
            public PaymentStatus Status { get; set; }
            public string? RefNumber { get; set; }
            public string? ExternalInfo1 { get; set; }
            public string? ExternalInfo2 { get; set; }
            public long Amount { get; set; }
            public string IpAddress { get; set; }
            public string? Description { get; set; }
            public int CurrencyTypeId { get; set; }
            public bool IsInPlace { get; set; }
            public string? ImageUrl { get; set; }
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
                var creditPayment = await _uow.CreditPaymentRepository.FindById(request.CreditPaymentId);
                if (creditPayment == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                creditPayment.AccountId = request.AccountId;
                creditPayment.AccountCreditId = request.AccountCreditId;
                creditPayment.Status = request.Status;
                creditPayment.RefNumber = request.RefNumber;
                creditPayment.ExternalInfo1 = request.ExternalInfo1;
                creditPayment.ExternalInfo2 = request.ExternalInfo2;
                creditPayment.IpAddress = request.IpAddress;
                creditPayment.Description = request.Description;
                creditPayment.CurrencyTypeId = request.CurrencyTypeId;
                creditPayment.IsInPlace = request.IsInPlace;
                creditPayment.ImageUrl = request.ImageUrl;
                creditPayment.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.CreditPaymentRepository.Update(creditPayment);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CreditPaymentId = request.CreditPaymentId
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
            public int CreditPaymentId { get; set; }
        }
    }
}
