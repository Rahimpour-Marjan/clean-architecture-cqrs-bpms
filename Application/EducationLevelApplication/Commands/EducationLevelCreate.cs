using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationLevelApplication.Commands
{
    public class EducationLevelCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
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
                    var eduLevel = new Domain.EducationLevel(request.Title,DateTime.Now);
                    var newEduLevelId = await _uow.EducationLevelRepository.Create(eduLevel);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationLevelId = newEduLevelId
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
            public int EducationLevelId { get; set; }
        }
    }
}
