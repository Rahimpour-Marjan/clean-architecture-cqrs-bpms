using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationFieldApplication.Commands
{
    public class EducationFieldCreate
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
                    var eduField = new Domain.EducationField(request.Title, DateTime.Now);
                    var newEduFieldId = await _uow.EducationFieldRepository.Create(eduField);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationFieldId = newEduFieldId
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
            public int EducationFieldId { get; set; }
        }
    }
}
