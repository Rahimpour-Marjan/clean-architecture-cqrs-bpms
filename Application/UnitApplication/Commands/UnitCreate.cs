using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UnitApplication.Commands
{
    public class UnitCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string AbbreviatedTitle { get; set; }
            public string? Description { get; set; }
            public DateTime DateRecord { get; set; }
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
                var Unit = new Domain.Unit(request.Title, request.AbbreviatedTitle, request.Description, DateTime.Now);
                try
                {
                    var newUnitId = await _uow.UnitRepository.Create(Unit);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            UnitId = newUnitId
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
            public int UnitId { get; set; }
        }
    }
}
