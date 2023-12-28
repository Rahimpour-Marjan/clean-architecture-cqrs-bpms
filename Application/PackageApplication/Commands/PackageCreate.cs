using Application.Common;
using Domain;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PackageApplication.Commands
{
    public class PackageCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public PackageType Type { get; set; }
            public string Code { get; set; }
            public bool IsActive { get; set; }
            public long Price { get; set; }
            public long? Discount { get; set; }
            public string? ImageUrl { get; set; }
            public DateTime? ExpireDate { get; set; }
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
                var package = new Package(request.Title, request.Type, request.Code, request.IsActive, request.Price, request.Discount, request.ImageUrl, request.ExpireDate, request.CreatorId);
                try
                {
                    var newPackageId = await _uow.PackageRepository.Create(package);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PackageId = newPackageId
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
