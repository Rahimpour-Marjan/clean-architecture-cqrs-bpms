using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Menu.Commands
{
    public class MenuCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public int Priority { get; set; }
            public bool IsActive { get; set; }
            public long? ParentId { get; set; }
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
                var menu = new Domain.Menu(request.Title, request.Url, request.Icon, request.Priority, request.IsActive, request.ParentId);
                try
                {
                    var newMenuId = await _uow.MenuRepository.Create(menu);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            MenuId = newMenuId
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
            public long MenuId { get; set; }
        }
    }
}
