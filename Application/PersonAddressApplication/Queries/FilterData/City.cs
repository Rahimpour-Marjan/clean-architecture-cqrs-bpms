using MediatR;
using Infrastructure.Persistance.Repositories;
using Domain.Common;

namespace Application.PersonAddressApplication.Queries.FilterData
{
    public class City
    {
        public class Query : IRequest<FilterResponse>
        {
            public int Start { get; set; }
            public int Length { get; set; }
        }

        public class Handler : IRequestHandler<Query, FilterResponse>
        {
            private readonly IUnitOfWork _uow;

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<FilterResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _uow.PersonAddressRepository.FilterAllCity(request.Start, request.Length);
            }
        }
    }
}
