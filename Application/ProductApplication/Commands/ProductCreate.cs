using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductApplication.Commands
{
    public class ProductCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int ProductTypeId { get; set; }
            public int ProductCategoryId { get; set; }
            public int? ProductBrandId { get; set; }
            public string? H1 { get; set; }
            public string? Url { get; set; }
            public string? CodeValue { get; set; }
            public string Summary { get; set; }
            public string? Description { get; set; }
            public string? Body { get; set; }
            public int? Priority { get; set; }
            public int? MaxShowCount { get; set; }
            public int? Quantity { get; set; }
            public int? MinOrder { get; set; }
            public long? LastPrice { get; set; }
            public long? Price { get; set; }
            public long? MinPrice { get; set; }
            public long? MaxPrice { get; set; }
            public int? VisitCount { get; set; }
            public bool ShowHomePage { get; set; }
            public string? Latitude { get; set; }
            public string? Longitude { get; set; }
            public int? SellCount { get; set; }
            public int? MaxOrderCount { get; set; }
            public long? DiscountValue { get; set; }
            public int? DiscountPercent { get; set; }
            public DateTime? DiscountExpireDate { get; set; }
            public string? MetaTagDescription { get; set; }
            public string? Canonical { get; set; }
            public bool NoFollow { get; set; }
            public bool NoIndex { get; set; }
            public string? Keywords { get; set; }
            public bool IsService { get; set; }
            public bool IsCopy { get; set; }
            public bool IsPublic { get; set; }
            public bool IsSpecial { get; set; }
            public bool PayLater { get; set; }
            public bool IsExport { get; set; }
            public bool IsActive { get; set; }
            public string? VideoDemoFileUrl { get; set; }
            public string? ImageUrl { get; set; }
            public int? CreatorStoreId { get; set; }
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
                var product = new Product(request.Title,request.ProductTypeId, request.ProductCategoryId, request.ProductBrandId, request.H1, request.Url,request.CodeValue,request.Summary, request.Description,
                    request.Body, request.Priority,request.MaxShowCount, request.Quantity, request.MinOrder, request.LastPrice, request.Price, request.MinPrice, request.MaxPrice, request.VisitCount, request.ShowHomePage, request.Latitude,
                    request.Longitude, request.SellCount, request.MaxOrderCount, request.DiscountValue, request.DiscountPercent, request.DiscountExpireDate, request.MetaTagDescription, request.Canonical,
                    request.NoFollow, request.NoIndex, request.Keywords, request.IsService, request.IsCopy, request.IsPublic, request.IsSpecial,  request.IsExport, request.PayLater,request.IsActive,
                    request.VideoDemoFileUrl, request.ImageUrl, request.CreatorStoreId, request.CreatorId);
                try
                {
                    var newProductId = await _uow.ProductRepository.Create(product);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductId = newProductId
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
            public int ProductId { get; set; }
        }
    }
}
