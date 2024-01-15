using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCategoryApplication.Commands
{
    public class ProductCategoryUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductCategoryId { get; set; }
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
                var productCategory = await _uow.ProductCategoryRepository.FindById(request.ProductCategoryId);
                if (productCategory == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                productCategory.Title = request.Title;
                productCategory.ProductCategoryParentId = request.ProductCategoryParentId;
                productCategory.IsActive = request.IsActive;
                productCategory.Url = request.Url;
                productCategory.Body = request.Body;
                productCategory.Deleted = request.Deleted;
                productCategory.Canonical = request.Canonical;
                productCategory.NoFollow = request.NoFollow;
                productCategory.NoIndex = request.NoIndex;
                productCategory.Priority = request.Priority;
                productCategory.ImageUrl = request.ImageUrl;
                productCategory.ModifireId = request.ModifireId;
                productCategory.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ProductCategoryRepository.Update(productCategory);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductCategoryId = request.ProductCategoryId
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
