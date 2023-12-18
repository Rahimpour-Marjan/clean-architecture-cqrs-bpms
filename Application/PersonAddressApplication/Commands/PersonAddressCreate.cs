using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PersonAddressApplication.Commands
{
    public class PersonAddressCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PersonId { get; set; }
            public string Title { get; set; }
            public string FullName { get; set; }
            public string Phone { get; set; }
            public string ExtraPhone { get; set; }
            public int CountryId { get; set; }
            public int StateId { get; set; }
            public int CityId { get; set; }
            public int? ZoneId { get; set; }
            public string Address { get; set; }
            public string ZipCode { get; set; }
            public string PostalCode { get; set; }
            public string? LocationLat { get; set; }
            public string? LocationLong { get; set; }
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
                var personAddress = new PersonAddress(request.PersonId, request.Title, request.FullName, request.Phone, request.ExtraPhone, request.CountryId, request.StateId, request.CityId, request.ZoneId, request.Address, request.ZipCode, request.PostalCode, request.LocationLat, request.LocationLong, DateTime.Now);
                try
                {
                    var newPersonAddressId = await _uow.PersonAddressRepository.Create(personAddress);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PersonAddressId = newPersonAddressId
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
            public int PersonAddressId { get; set; }
        }
    }
}
