using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ZoneApplication.Commands
{
    public class ZoneUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ZoneId { get; set; }
            public string Title { get; set; }
            public int CityId { get; set; }
            public string Code { get; set; }
            public string? ZipCode { get; set; }
            public string? PostalCode { get; set; }
            public string? LocationLat { get; set; }
            public string? LocationLong { get; set; }
            public string? ImageUrl { get; set; }
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
                var zone = await _uow.ZoneRepository.FindById(request.ZoneId);
                if (zone == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                zone.Title = request.Title;
                zone.CityId = request.CityId;
                zone.Code = request.Code;
                zone.ZipCode = request.ZipCode;
                zone.PostalCode = request.PostalCode;
                zone.LocationLat = request.LocationLat;
                zone.LocationLong = request.LocationLong;
                zone.ImageUrl = request.ImageUrl;
                zone.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ZoneRepository.Update(zone);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ZoneId = request.ZoneId
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
            public int ZoneId { get; set; }
        }
    }
}
