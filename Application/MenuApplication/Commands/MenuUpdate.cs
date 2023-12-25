using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Menu.Commands
{
    public class MenuUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
            public int Priority { get; set; }
            public bool IsActive { get; set; }
            public long? ParentId { get; set; }
            public string Key { get; set; }
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
                var menu = await _uow.MenuRepository.FindById(request.Id);
                if (menu == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                menu.Title = request.Title;
                menu.Url = request.Url;
                menu.Icon = request.Icon;
                menu.Priority = request.Priority;
                menu.IsActive = request.IsActive;
                menu.ParentId = request.ParentId;

                try
                {
                    await _uow.MenuRepository.Update(menu);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            MenuId = request.Id
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
