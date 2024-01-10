using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountAddressApplication.Commands
{
    public class AccountAddressUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountAddressId { get; set; }
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
                var accountAddress = await _uow.AccountAddressRepository.FindById(request.AccountAddressId);
                if (accountAddress == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                accountAddress.Title = request.Title;
                accountAddress.FullName = request.FullName;
                accountAddress.Phone = request.Phone;
                accountAddress.ExtraPhone = request.ExtraPhone;
                accountAddress.CountryId = request.CountryId;
                accountAddress.StateId = request.StateId;
                accountAddress.CityId = request.CityId;
                accountAddress.ZoneId = request.ZoneId;
                accountAddress.Address = request.Address;
                accountAddress.ZipCode = request.ZipCode;
                accountAddress.PostalCode = request.PostalCode;
                accountAddress.LocationLat = request.LocationLat;
                accountAddress.LocationLong = request.LocationLong;
                accountAddress.ModifireId =request.ModifireId;
                accountAddress.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.AccountAddressRepository.Update(accountAddress);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountAddressId = request.AccountAddressId
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
            public int AccountAddressId { get; set; }
        }
    }
}
