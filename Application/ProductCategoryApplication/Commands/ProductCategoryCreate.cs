using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCategoryApplication.Commands
{
    public class ProductCategoryCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int? ProductCategoryParentId { get; set; }
            public bool IsActive { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
            public bool? Deleted { get; set; }
            public string? Canonical { get; set; }
            public bool? NoFollow { get; set; }
            public bool? NoIndex { get; set; }
            public int? Priority { get; set; }
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
                var productCategory = new ProductCategory(request.Title,request.ProductCategoryParentId, request.IsActive, request.Url, request.Body, request.Deleted, request.Canonical, request.NoFollow, request.NoIndex, request.Priority, request.ImageUrl, request.CreatorId);
                try
                {
                    var newProductCategoryId = await _uow.ProductCategoryRepository.Create(productCategory);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductCategoryId = newProductCategoryId
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
            public int ProductCategoryId { get; set; }
        }
    }
}
