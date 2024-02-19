using Application.ProductApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductApplication.Queries.FindAll
{
    public class FindAllProductQueryHandler : IRequestHandler<FindAllProductQuery, FindAllQueryResponse<IList<ProductInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ProductInfo>>> Handle(FindAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ProductRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Product, ProductInfo>).ToList();

                return FindAllQueryResponse<IList<ProductInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ProductInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
