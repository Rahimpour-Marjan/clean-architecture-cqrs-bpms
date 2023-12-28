using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CurrencyTypeApplication.Commands
{
    public class CurrencyTypeUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CurrencyTypeId { get; set; }
            public string Title { get; set; }
            public string CurrencySign { get; set; }
            public long UnitPrice { get; set; }
            public string? ImageUrl { get; set; }
            public int ModifireId { get; set; }
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
                var currencyType = await _uow.CurrencyTypeRepository.FindById(request.CurrencyTypeId);
                if (currencyType == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                currencyType.Title = request.Title;
                currencyType.CurrencySign = request.CurrencySign;
                currencyType.UnitPrice = request.UnitPrice;
                currencyType.ImageUrl = request.ImageUrl;
                currencyType.ModifireId = request.ModifireId;
                currencyType.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.CurrencyTypeRepository.Update(currencyType);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CurrencyTypeId = request.CurrencyTypeId
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
            public int CurrencyTypeId { get; set; }
        }
    }
}
