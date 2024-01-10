using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.BankApplication.Commands
{
    public class BankCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public string? ImageUrl { get; set; }
            public int CreatorId { get; set; }
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
                var bank = new Bank(request.Title, request.IsActive, request.ImageUrl, request.CreatorId);
                try
                {
                    var newBankId = await _uow.BankRepository.Create(bank);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            BankId = newBankId
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
            public int BankId { get; set; }
        }
    }
}
