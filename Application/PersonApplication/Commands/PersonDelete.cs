using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Person.Commands
{
    public class PersonDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int EmpId { get; set; }
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
                    await _uow.PersonRepository.Delete(request.EmpId);
                    await _uow.PersonRepository.PersonJuncPostDelete(request.EmpId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {

                            PersonId = request.EmpId
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
            public int PersonId { get; set; }
        }
    }
}
