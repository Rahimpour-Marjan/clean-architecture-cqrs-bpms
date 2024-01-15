using Application.ProductCategoryApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCategoryApplication.Queries.FindAll
{
    public class FindAllProductCategoryQueryHandler : IRequestHandler<FindAllProductCategoryQuery, FindAllQueryResponse<IList<ProductCategoryInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllProductCategoryQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ProductCategoryInfo>>> Handle(FindAllProductCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ProductCategoryRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.ProductCategory, ProductCategoryInfo>).ToList();

                return FindAllQueryResponse<IList<ProductCategoryInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ProductCategoryInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
