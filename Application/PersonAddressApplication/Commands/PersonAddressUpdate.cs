using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PersonAddressApplication.Commands
{
    public class PersonAddressUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int PersonAddressId { get; set; }
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
                var personAddress = await _uow.PersonAddressRepository.FindById(request.PersonAddressId);
                if (personAddress == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                personAddress.Title = request.Title;
                personAddress.FullName = request.FullName;
                personAddress.Phone = request.Phone;
                personAddress.ExtraPhone = request.ExtraPhone;
                personAddress.CountryId = request.CountryId;
                personAddress.StateId = request.StateId;
                personAddress.CityId = request.CityId;
                personAddress.ZoneId = request.ZoneId;
                personAddress.Address = request.Address;
                personAddress.ZipCode = request.ZipCode;
                personAddress.PostalCode = request.PostalCode;
                personAddress.LocationLat = request.LocationLat;
                personAddress.LocationLong = request.LocationLong;
                personAddress.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.PersonAddressRepository.Update(personAddress);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            PersonAddressId = request.PersonAddressId
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
