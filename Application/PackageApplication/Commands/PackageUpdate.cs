using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PackageApplication.Commands
{
    public class PackageUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PackageId { get; set; }
            public string Title { get; set; }
            public PackageType Type { get; set; }
            public string Code { get; set; }
            public bool IsActive { get; set; }
            public long Price { get; set; }
            public long? Discount { get; set; }
            public string? ImageUrl { get; set; }
            public DateTime? ExpireDate { get; set; }
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
                var package = await _uow.PackageRepository.FindById(request.PackageId);
                if (package == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                package.Title = request.Title;
                package.Type = request.Type;
                package.Code = request.Code;
                package.IsActive = request.IsActive;
                package.Price = request.Price;
                package.Discount = request.Discount;
                package.ImageUrl = request.ImageUrl;
                package.ExpireDate = request.ExpireDate;
                package.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.PackageRepository.Update(package);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PackageId = request.PackageId
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
            public int PackageId { get; set; }
        }
    }
}
