using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UnitApplication.Commands
{
    public class UnitUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int UnitId { get; set; }
            public string Title { get; set; }
            public string AbbreviatedTitle { get; set; }
            public string? Description { get; set; }
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
                var unit = await _uow.UnitRepository.FindById(request.UnitId);
                if (unit == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                unit.Title = request.Title;
                unit.AbbreviatedTitle = request.AbbreviatedTitle;
                unit.Description = request.Description;

                try
                {
                    await _uow.UnitRepository.Update(unit);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            UnitId = request.UnitId
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
