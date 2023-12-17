using AutoMapper;
using MediatR;
using System.Data;
using Application.Person.Models;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Domain.Resources;
using Domain;

namespace Application.Person.Queries.FindAll
{
    public class FindAllPersonQueryHandler : IRequestHandler<FindAllPersonQuery, FindAllQueryResponse<IList<Models.PersonView>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllPersonQueryHandler( IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<Models.PersonView>>> Handle(FindAllPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.PersonRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.PersonView, Models.PersonView>).ToList();
               
                return FindAllQueryResponse<IList<Models.PersonView>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<Models.PersonView>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
