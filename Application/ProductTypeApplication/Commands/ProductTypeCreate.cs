using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Commands
{
    public class ProductTypeCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int? ProductTypeParentId { get; set; }
            public bool IsActive { get; set; }
            public string H1 { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
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
                var productType = new ProductType(request.Title,request.ProductTypeParentId, request.IsActive, request.H1, request.Url, request.Body, request.Priority, request.ImageUrl, request.CreatorId);
                try
                {
                    var newProductTypeId = await _uow.ProductTypeRepository.Create(productType);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductTypeId = newProductTypeId
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
            public int ProductTypeId { get; set; }
        }
    }
}
