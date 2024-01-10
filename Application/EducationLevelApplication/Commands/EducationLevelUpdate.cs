using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationLevelApplication.Commands
{
    public class EducationLevelUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int EduLevelId { get; set; }
            public string Title { get; set; }
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
                var eduLevel = await _uow.EducationLevelRepository.FindById(request.EduLevelId);
                if (eduLevel == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                eduLevel.Title = request.Title;
                eduLevel.ModifireId = request.ModifireId;
                eduLevel.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.EducationLevelRepository.Update(eduLevel);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            EducationLevelId = request.EduLevelId
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
