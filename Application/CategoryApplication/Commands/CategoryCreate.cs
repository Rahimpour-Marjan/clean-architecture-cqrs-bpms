using Application.Common;
using Domain;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CategoryApplication.Commands
{
    public class CategoryCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public CategoryType Type { get; set; }
            public bool IsActive { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
            public string? ImageUrl { get; set; }
            public int CreatorId { get; set; }
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
                var category = new Category(request.Title, request.Type, request.IsActive, request.Url, request.Body, request.ImageUrl, request.CreatorId);
                try
                {
                    var newCategoryId = await _uow.CategoryRepository.Create(category);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CategoryId = newCategoryId
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
