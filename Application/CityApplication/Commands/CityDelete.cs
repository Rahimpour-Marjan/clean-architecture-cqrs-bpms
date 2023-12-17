using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CityApplication.Commands
{
    public class CityDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CityId { get; set; }
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
                    await _uow.CityRepository.Delete(request.CityId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CityId = request.CityId
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
            public int CityId { get; set; }
        }
    }
}
