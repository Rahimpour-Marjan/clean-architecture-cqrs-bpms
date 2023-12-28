using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.QuickAccess.Commands
{
    public class QuickAccessUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string SitePageKey { get; set; }
            public int DisplayPriority { get; set; }
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
                try
                {
                    var varSitePage = await _uow.SitePageRepository.FindByKey(request.SitePageKey);
                    if (varSitePage == null)
                        return OperationResult<Response>.BuildFailure("Key not found!");
                    var quickaccess = await _uow.QuickAccessRepository.FindById(request.Id, request.UserId);
                    if (quickaccess == null)
                        return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                    var duplicateQuickaccess = await _uow.QuickAccessRepository.FindWithParam(request.UserId, varSitePage.Id);
                    if (duplicateQuickaccess == null || duplicateQuickaccess.Id == request.Id)
                    {
                        quickaccess.UserId = request.UserId;
                        quickaccess.SitePageId = varSitePage.Id;
                        quickaccess.Priority = request.DisplayPriority;
                        quickaccess.ModifireId = request.ModifireId;
                        quickaccess.ModifiedDate = DateTime.Now;

                        await _uow.QuickAccessRepository.Update(quickaccess);
                        var result = OperationResult<Response>
                            .BuildSuccessResult(new Response
                            {
                                QuickAccessId = request.Id
                            });
                        await Task.CompletedTask;
                        return result;
                    }
                    else
                    {
                        return OperationResult<Response>.BuildFailure("Duplicate record.");
                    }
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
            public int QuickAccessId { get; set; }
        }
    }
}