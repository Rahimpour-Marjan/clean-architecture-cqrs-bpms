using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.StateApplication.Commands
{
    public class StateDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int StateId { get; set; }
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
                    await _uow.StateRepository.Delete(request.StateId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            StateId = request.StateId
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
            public int StateId { get; set; }
        }
    }
}
