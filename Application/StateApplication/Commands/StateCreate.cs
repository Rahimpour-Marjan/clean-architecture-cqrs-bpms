using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.StateApplication.Commands
{
    public class StateCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int CountryId { get; set; }
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
                var state = new State(request.Title,request.CountryId, request.Code, request.ZipCode, request.PostalCode, request.LocationLat, request.LocationLong, request.ImageUrl, DateTime.Now);
                try
                {
                    var newStateId = await _uow.StateRepository.Create(state);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            StateId = newStateId
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
            public int StateId { get; set; }
        }
    }
}
