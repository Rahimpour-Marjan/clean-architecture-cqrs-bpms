using Application.Common;
using Application.EducationLevelApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.EducationLevelApplication.Queries.FindAll
{
    public class FindAllEducationLevelQueryHandler : IRequestHandler<FindAllEducationLevelQuery, FindAllQueryResponse<IList<EducationLevelInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllEducationLevelQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<EducationLevelInfo>>> Handle(FindAllEducationLevelQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.EducationLevelRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.EducationLevel, EducationLevelInfo>).ToList();

                return FindAllQueryResponse<IList<EducationLevelInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<EducationLevelInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
