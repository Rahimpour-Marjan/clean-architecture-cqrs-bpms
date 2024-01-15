using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductBrandApplication.Commands
{
    public class ProductBrandCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int ProductTypeId { get; set; }
            public bool IsActive { get; set; }
            public string H1 { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
            public string? Description { get; set; }
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
                var productBrand = new ProductBrand(request.Title,request.ProductTypeId, request.IsActive, request.H1, request.Url, request.Body,  request.Description, request.Priority, request.ImageUrl, request.CreatorId);
                try
                {
                    var newProductBrandId = await _uow.ProductBrandRepository.Create(productBrand);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductBrandId = newProductBrandId
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
