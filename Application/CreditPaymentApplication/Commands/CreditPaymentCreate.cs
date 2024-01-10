using Application.Common;
using Domain;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CreditPaymentApplication.Commands
{
    public class CreditPaymentCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
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
            public int CreatorId { get; set; }
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
                var creditPayment = new CreditPayment(request.AccountId, request.AccountCreditId, request.Status, request.RefNumber, request.ExternalInfo1, request.ExternalInfo2, request.Amount, request.IpAddress, request.Description, request.CurrencyTypeId, request.IsInPlace, request.ImageUrl, request.CreatorId);
                try
                {
                    var newCreditPaymentId = await _uow.CreditPaymentRepository.Create(creditPayment);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CreditPaymentId = newCreditPaymentId
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
