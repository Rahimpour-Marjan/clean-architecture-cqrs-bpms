using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.StateApplication.Commands
{
    public class StateUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int StateId { get; set; }
            public string Title { get; set; }
            public int CountryId { get; set; }
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
                var state = await _uow.StateRepository.FindById(request.StateId);
                if (state == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                state.Title = request.Title;
                state.CountryId = request.CountryId;
                state.Code = request.Code;
                state.ZipCode = request.ZipCode;
                state.PostalCode = request.PostalCode;
                state.LocationLat = request.LocationLat;
                state.LocationLong = request.LocationLong;
                state.ImageUrl = request.ImageUrl;
                state.ModifireId = request.ModifireId;
                state.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.StateRepository.Update(state);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            StateId = request.StateId
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
