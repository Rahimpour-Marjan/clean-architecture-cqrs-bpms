using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CategoryApplication.Commands
{
    public class CategoryUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CategoryId { get; set; }
            public string Title { get; set; }
            public CategoryType Type { get; set; }
            public bool IsActive { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
            public string? ImageUrl { get; set; }
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
                var category = await _uow.CategoryRepository.FindById(request.CategoryId);
                if (category == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                category.Title = request.Title;
                category.Type = request.Type;
                category.IsActive = request.IsActive;
                category.Url = request.Url;
                category.Body = request.Body;
                category.ImageUrl = request.ImageUrl;
                category.ModifireId = request.ModifireId;
                category.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.CategoryRepository.Update(category);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CategoryId = request.CategoryId
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
            public int CategoryId { get; set; }
        }
    }
}
