using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.Person.Commands
{
    public class PersonDeleteAll
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int[] Ids { get; set; }
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
                    await _uow.PersonRepository.PersonDeleteAll(request.Ids);
                    await _uow.PersonRepository.PersonJuncPostDeleteAll(request.Ids);
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
