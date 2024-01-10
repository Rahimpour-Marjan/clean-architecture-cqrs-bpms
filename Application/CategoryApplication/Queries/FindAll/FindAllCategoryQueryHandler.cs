using Application.CategoryApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CategoryApplication.Queries.FindAll
{
    public class FindAllCategoryQueryHandler : IRequestHandler<FindAllCategoryQuery, FindAllQueryResponse<IList<CategoryInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllCategoryQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<CategoryInfo>>> Handle(FindAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.CategoryRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Category, CategoryInfo>).ToList();

                return FindAllQueryResponse<IList<CategoryInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<CategoryInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
