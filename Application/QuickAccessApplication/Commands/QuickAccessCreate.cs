using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.QuickAccess.Commands
{
    public class QuickAccessCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int UserId { get; set; }
            public string SitePageKey { get; set; }
            public int DisplayPriority { get; set; }
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
                    var quickaccess = await _uow.QuickAccessRepository.FindWithParam(request.UserId, varSitePage.Id);
                    if (quickaccess == null)
                    {
                        var newQuickaccess = new Domain.QuickAccess(request.UserId, varSitePage.Id, request.DisplayPriority);
                        var newQAId = await _uow.QuickAccessRepository.Create(newQuickaccess);
                        var result = OperationResult<Response>
                            .BuildSuccessResult(new Response
                            {
                                QuickAccessId = newQAId
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