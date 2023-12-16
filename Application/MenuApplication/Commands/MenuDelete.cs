using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Menu.Commands
{
    public class MenuDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public long Id { get; set; }
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
                    await _uow.MenuRepository.Delete(request.Id);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            MenuId = request.Id
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
            public long MenuId { get; set; }
        }
    }
}
