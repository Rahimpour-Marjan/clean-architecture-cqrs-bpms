using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductApplication.Commands
{
    public class ProductUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductId { get; set; }
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
                var product = await _uow.ProductRepository.FindById(request.ProductId);
                if (product == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                product.Title = request.Title;
                product.ProductTypeId = request.ProductTypeId;
                product.ProductCategoryId = request.ProductCategoryId;
                product.ProductBrandId = request.ProductBrandId;
                product.H1 = request.H1;
                product.Url = request.Url;
                product.CodeValue = request.CodeValue;
                product.Summary = request.Summary;
                product.Description = request.Description;
                product.Body = request.Body;
                product.Priority = request.Priority;
                product.MaxShowCount = request.MaxShowCount;
                product.Quantity = request.Quantity;
                product.MinOrder = request.MinOrder;
                product.LastPrice = request.LastPrice;
                product.Price = request.Price;
                product.MinPrice = request.MinPrice;
                product.MaxPrice = request.MaxPrice;
                product.VisitCount = request.VisitCount;
                product.ShowHomePage = request.ShowHomePage;
                product.Latitude = request.Latitude;
                product.Longitude = request.Longitude;
                product.SellCount = request.SellCount;
                product.MaxOrderCount = request.MaxOrderCount;
                product.DiscountValue = request.DiscountValue;
                product.DiscountPercent = request.DiscountPercent;
                product.DiscountExpireDate = request.DiscountExpireDate;
                product.MetaTagDescription = request.MetaTagDescription;
                product.Canonical = request.Canonical;
                product.NoFollow = request.NoFollow;
                product.NoIndex = request.NoIndex;
                product.Keywords = request.Keywords;
                product.IsService = request.IsService;
                product.IsCopy = request.IsCopy;
                product.IsPublic = request.IsPublic;
                product.IsSpecial = request.IsSpecial;
                product.PayLater = request.PayLater;
                product.IsExport = request.IsExport;
                product.IsActive = request.IsActive;
                product.VideoDemoFileUrl = request.VideoDemoFileUrl;
                product.ImageUrl = request.ImageUrl;
                product.ModifireId = request.ModifireId;
                product.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ProductRepository.Update(product);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductId = request.ProductId
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
