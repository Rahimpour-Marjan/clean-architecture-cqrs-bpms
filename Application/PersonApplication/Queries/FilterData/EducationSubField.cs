using MediatR;
using Infrastructure.Persistance.Repositories;
using Domain.Common;

namespace Application.PersonApplication.Queries.FilterData
{
    public class EducationSubField
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
                return await _uow.PersonRepository.FilterAllEducationSubField(request.Start, request.Length);
            }
        }
    }
}
