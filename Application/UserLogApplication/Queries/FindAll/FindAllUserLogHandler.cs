using Application.Common;
using Application.UserLogApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserLogApplication.Queries.FindAll
{
    class FindAllUserLogHandler : IRequestHandler<FindAllUserLogQuery, FindAllQueryResponse<IList<UserLogInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllUserLogHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<UserLogInfo>>> Handle(FindAllUserLogQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.UserLogRepository.FindAll(request.UserId, queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.UserLog, UserLogInfo>).ToList();

                return FindAllQueryResponse<IList<UserLogInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<UserLogInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
