using Application.Common;
using Application.Menu.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Menu.Queries.FindAllWithFilter
{
    internal class FindAllMenuWithFilterQueryHandler : IRequestHandler<FindAllMenuWithFilterQuery, FindAllQueryResponse<IList<MenuInfo>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FindAllMenuWithFilterQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<MenuInfo>>> Handle(FindAllMenuWithFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.MenuRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Menu, MenuInfo>).ToList();

                return FindAllQueryResponse<IList<MenuInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<MenuInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
