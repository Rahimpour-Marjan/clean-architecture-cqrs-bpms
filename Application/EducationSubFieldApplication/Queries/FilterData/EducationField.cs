using Application.Common;
using Domain.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.EducationSubFieldApplication.Queries.FilterData
{
    public class EducationField
    {
        public class Query : IRequest<OperationResult<FilterResponse>>
        {
            public int Start { get; set; }
            public int Length { get; set; }
            public string ColumName { get; set; }
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
                if (string.Equals(request.ColumName.ToLower(), nameof(Domain.EducationField).ToLower()))
                {
                    var model = await _uow.EducationSubFieldRepository.FilterAllEducationField(request.Start, request.Length);
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
                else
                {
                    return OperationResult<FilterResponse>.BuildFailure("لطفا نام ستون را درست وارد نمایید.");
                }
            }
        }
    }
}
