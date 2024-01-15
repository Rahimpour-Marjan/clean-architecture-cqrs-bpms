using Domain.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Queries.FilterData
{
    public class ProductTypeParent
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
                return await _uow.ProductTypeRepository.FilterAllProductTypeParent(request.Start, request.Length);
            }
        }
    }
}
