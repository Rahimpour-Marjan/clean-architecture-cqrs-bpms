using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CurrencyTypeApplication.Commands
{
    public class CurrencyTypeDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CurrencyTypeId { get; set; }
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
                    await _uow.CurrencyTypeRepository.Delete(request.CurrencyTypeId);
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
