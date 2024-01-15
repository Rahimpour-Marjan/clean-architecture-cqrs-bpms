using Application.ProductTypeApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductTypeApplication.Queries.FindAll
{
    public class FindAllProductTypeQueryHandler : IRequestHandler<FindAllProductTypeQuery, FindAllQueryResponse<IList<ProductTypeInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllProductTypeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ProductTypeInfo>>> Handle(FindAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ProductTypeRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.ProductType, ProductTypeInfo>).ToList();

                return FindAllQueryResponse<IList<ProductTypeInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ProductTypeInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
