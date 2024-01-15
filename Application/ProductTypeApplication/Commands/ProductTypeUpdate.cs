using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Commands
{
    public class ProductTypeUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductTypeId { get; set; }
            public string Title { get; set; }
            public int? ProductTypeParentId { get; set; }
            public bool IsActive { get; set; }
            public string H1 { get; set; }
            public string? Url { get; set; }
            public string? Body { get; set; }
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
                var productType = await _uow.ProductTypeRepository.FindById(request.ProductTypeId);
                if (productType == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                productType.Title = request.Title;
                productType.ProductTypeParentId = request.ProductTypeParentId;
                productType.IsActive = request.IsActive;
                productType.H1 = request.H1;
                productType.Url = request.Url;
                productType.Body = request.Body;
                productType.Priority = request.Priority;
                productType.ImageUrl = request.ImageUrl;
                productType.ModifireId = request.ModifireId;
                productType.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ProductTypeRepository.Update(productType);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductTypeId = request.ProductTypeId
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
