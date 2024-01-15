using Application.ProductBrandApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductBrandApplication.Queries.FindAll
{
    public class FindAllProductBrandQueryHandler : IRequestHandler<FindAllProductBrandQuery, FindAllQueryResponse<IList<ProductBrandInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllProductBrandQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ProductBrandInfo>>> Handle(FindAllProductBrandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ProductBrandRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.ProductBrand, ProductBrandInfo>).ToList();

                return FindAllQueryResponse<IList<ProductBrandInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ProductBrandInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
