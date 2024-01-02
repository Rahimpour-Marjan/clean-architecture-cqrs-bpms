using Domain.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ArticleApplication.Queries.FilterData
{
    public class Category
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
                return await _uow.ArticleRepository.FilterAllCategory(request.Start, request.Length);
            }
        }
    }
}
