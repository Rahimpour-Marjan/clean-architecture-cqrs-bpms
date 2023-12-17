using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PackageApplication.Commands
{
    public class PackageDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PackageId { get; set; }
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
                    await _uow.PackageRepository.Delete(request.PackageId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PackageId = request.PackageId
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
            public int PackageId { get; set; }
        }
    }
}
