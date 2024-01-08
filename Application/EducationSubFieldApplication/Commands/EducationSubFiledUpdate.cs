using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationSubFieldApplication.Commands
{
    public class EducationSubFieldUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int EducationFieldId { get; set; }
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
                var eduSubField = await _uow.EducationSubFieldRepository.FindById(request.Id);
                if (eduSubField == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                eduSubField.Title = request.Title;
                eduSubField.EducationFieldId = request.EducationFieldId;
                eduSubField.ModifireId = request.ModifireId;
                eduSubField.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.EducationSubFieldRepository.Update(eduSubField);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationSubFieldId = request.Id
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
