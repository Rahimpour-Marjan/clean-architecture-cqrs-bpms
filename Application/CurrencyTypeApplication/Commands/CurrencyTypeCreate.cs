using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CurrencyTypeApplication.Commands
{
    public class CurrencyTypeCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string CurrencySign { get; set; }
            public long UnitPrice { get; set; }
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
                var currencyType = new CurrencyType(request.Title, request.CurrencySign, request.UnitPrice, request.ImageUrl, request.CreatorId);
                try
                {
                    var newCurrencyTypeId = await _uow.CurrencyTypeRepository.Create(currencyType);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CurrencyTypeId = newCurrencyTypeId
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
