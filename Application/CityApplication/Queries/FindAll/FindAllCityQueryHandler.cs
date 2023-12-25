using Application.CityApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CityApplication.Queries.FindAll
{
    public class FindAllCityQueryHandler : IRequestHandler<FindAllCityQuery, FindAllQueryResponse<IList<CityInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllCityQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<CityInfo>>> Handle(FindAllCityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.CityRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.City, CityInfo>).ToList();

                return FindAllQueryResponse<IList<CityInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<CityInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
