using Application.Common;
using Application.CountryApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CountryApplication.Queries.FindAll
{
    public class FindAllCountryQueryHandler : IRequestHandler<FindAllCountryQuery, FindAllQueryResponse<IList<CountryInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllCountryQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<CountryInfo>>> Handle(FindAllCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.CountryRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Country, CountryInfo>).ToList();

                return FindAllQueryResponse<IList<CountryInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<CountryInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
