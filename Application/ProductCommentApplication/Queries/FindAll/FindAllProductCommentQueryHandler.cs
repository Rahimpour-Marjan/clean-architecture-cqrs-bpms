using Application.ProductCommentApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCommentApplication.Queries.FindAll
{
    public class FindAllProductCommentQueryHandler : IRequestHandler<FindAllProductCommentQuery, FindAllQueryResponse<IList<ProductCommentInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllProductCommentQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ProductCommentInfo>>> Handle(FindAllProductCommentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ProductCommentRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.ProductComment, ProductCommentInfo>).ToList();

                return FindAllQueryResponse<IList<ProductCommentInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ProductCommentInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
