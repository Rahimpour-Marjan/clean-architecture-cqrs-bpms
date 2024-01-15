using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductBrandApplication.Commands
{
    public class ProductBrandUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductBrandId { get; set; }
            public string Title { get; set; }
            public int ProductTypeId { get; set; }
            public bool IsActive { get; set; }
            public string H1 { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
            public string? Description { get; set; }
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
                var productBrand = await _uow.ProductBrandRepository.FindById(request.ProductBrandId);
                if (productBrand == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                productBrand.Title = request.Title;
                productBrand.ProductTypeId = request.ProductTypeId;
                productBrand.IsActive = request.IsActive;
                productBrand.H1 = request.H1;
                productBrand.Url = request.Url;
                productBrand.Body = request.Body;
                productBrand.Description = request.Description;
                productBrand.Priority = request.Priority;
                productBrand.ImageUrl = request.ImageUrl;
                productBrand.ModifireId = request.ModifireId;
                productBrand.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ProductBrandRepository.Update(productBrand);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductBrandId = request.ProductBrandId
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
            public int ProductBrandId { get; set; }
        }
    }
}
