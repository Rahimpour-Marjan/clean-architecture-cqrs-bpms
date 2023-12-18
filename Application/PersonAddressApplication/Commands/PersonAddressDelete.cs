using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PersonAddressApplication.Commands
{
    public class PersonAddressDelete
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PersonAddressId { get; set; }
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
                    await _uow.PersonAddressRepository.Delete(request.PersonAddressId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PersonAddressId = request.PersonAddressId
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
            public int PersonAddressId { get; set; }
        }
    }
}
