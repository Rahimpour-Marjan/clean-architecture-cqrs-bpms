using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationFieldApplication.Commands
{
    public class EducationFieldUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int EduFieldId { get; set; }
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
                var eduField = await _uow.EducationFieldRepository.FindById(request.EduFieldId);
                if (eduField == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                eduField.Title = request.Title;
                eduField.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.EducationFieldRepository.Update(eduField);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationFieldId = request.EduFieldId
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
