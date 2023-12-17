using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CityApplication.Commands
{
    public class CityUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CityId { get; set; }
            public string Title { get; set; }
            public int StateId { get; set; }
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
                var city = await _uow.CityRepository.FindById(request.CityId);
                if (city == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                city.Title = request.Title;
                city.StateId = request.StateId;
                city.Code = request.Code;
                city.ZipCode = request.ZipCode;
                city.PostalCode = request.PostalCode;
                city.LocationLat = request.LocationLat;
                city.LocationLong = request.LocationLong;
                city.ImageUrl = request.ImageUrl;
                city.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.CityRepository.Update(city);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CityId = request.CityId
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
            public int CityId { get; set; }
        }
    }
}
