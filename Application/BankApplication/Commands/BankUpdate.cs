using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.BankApplication.Commands
{
    public class BankUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int BankId { get; set; }
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public string? ImageUrl { get; set; }
            public int ModifireId { get; set; }
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
                var bank = await _uow.BankRepository.FindById(request.BankId);
                if (bank == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                bank.Title = request.Title;
                bank.IsActive = request.IsActive;
                bank.ImageUrl = request.ImageUrl;
                bank.ModifireId = request.ModifireId;
                bank.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.BankRepository.Update(bank);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            BankId = request.BankId
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
