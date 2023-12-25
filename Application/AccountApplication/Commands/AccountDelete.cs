using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Account.Commands
{
    public class AccountDelete
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
                    await _uow.AccountRepository.Delete(request.EmpId);
                    await _uow.AccountRepository.AccountJuncPostDelete(request.EmpId);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {

                            AccountId = request.EmpId
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
            public int AccountId { get; set; }
        }
    }
}
