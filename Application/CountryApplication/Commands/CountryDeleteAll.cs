using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CountryApplication.Commands
{
    public class CountryDeleteAll
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int[] CountryIds { get; set; }
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
                    await _uow.CountryRepository.DeleteAll(request.CountryIds);

                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            Result = true
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
            public bool Result { get; set; }
        }
    }
}
