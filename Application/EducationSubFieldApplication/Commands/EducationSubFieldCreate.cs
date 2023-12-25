using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationSubFieldApplication.Commands
{
    public class EducationSubFieldCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int EducationFieldId { get; set; }
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
                    var eduSubField = new Domain.EducationSubField(request.Title, request.EducationFieldId,DateTime.Now);
                    var newEduSubFieldId = await _uow.EducationSubFieldRepository.Create(eduSubField);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationSubFieldId = newEduSubFieldId
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
            public int EducationSubFieldId { get; set; }
        }
    }
}
