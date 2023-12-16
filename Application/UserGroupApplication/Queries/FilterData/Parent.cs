using MediatR;
using Infrastructure.Persistance.Repositories;
using Domain.Common;
using Application.Common;

namespace Application.UserGroupApplication.Queries.FilterData
{
    public class Parent
    {
        public class Query : IRequest<OperationResult<FilterResponse>>
        {
            public int Start { get; set; }
            public int Length { get; set; }
        }

        public class Handler : IRequestHandler<Query, OperationResult<FilterResponse>>
        {
            private readonly IUnitOfWork _uow;

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<OperationResult<FilterResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var model = await _uow.UserGroupRepository.FilterAllParent(request.Start, request.Length);
                var result = OperationResult<FilterResponse>
                       .BuildSuccessResult(new FilterResponse
                       {
                           Data = model.Data,
                           Length = model.Length,
                           Start = request.Start,
                           TotalRecords = model.TotalRecords,
                       });
                await Task.CompletedTask;
                return result;
            }
        }
    }
}
