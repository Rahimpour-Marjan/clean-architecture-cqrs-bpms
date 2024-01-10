using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountAddressApplication.Commands
{
    public class AccountAddressCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int AccountId { get; set; }
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
                var accountAddress = new AccountAddress(request.AccountId, request.Title, request.FullName, request.Phone, request.ExtraPhone, request.CountryId, request.StateId, request.CityId, request.ZoneId, request.Address, request.ZipCode, request.PostalCode, request.LocationLat, request.LocationLong,request.CreatorId);
                try
                {
                    var newAccountAddressId = await _uow.AccountAddressRepository.Create(accountAddress);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            AccountAddressId = newAccountAddressId
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
