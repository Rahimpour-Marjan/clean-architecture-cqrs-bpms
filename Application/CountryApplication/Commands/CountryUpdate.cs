using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CountryApplication.Commands
{
    public class CountryUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int CountryId { get; set; }
            public string Title { get; set; }
            public string Code { get; set; }
            public string? ZipCode { get; set; }
            public string? PostalCode { get; set; }
            public string? LocationLat { get; set; }
            public string? LocationLong { get; set; }
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
                var country = await _uow.CountryRepository.FindById(request.CountryId);
                if (country == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                country.Title = request.Title;
                country.Code = request.Code;
                country.ZipCode = request.ZipCode;
                country.PostalCode = request.PostalCode;
                country.LocationLat = request.LocationLat;
                country.LocationLong = request.LocationLong;
                country.ImageUrl = request.ImageUrl;
                country.ModifireId = request.ModifireId;
                country.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.CountryRepository.Update(country);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            CountryId = request.CountryId
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
            public int CountryId { get; set; }
        }
    }
}
