using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.PersonAddressApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.PersonAddressApplication.Queries.FindAll
{
    public class FindAllPersonAddressQueryHandler : IRequestHandler<FindAllPersonAddressQuery, FindAllQueryResponse<IList<PersonAddressInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllPersonAddressQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<PersonAddressInfo>>> Handle(FindAllPersonAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.PersonAddressRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.PersonAddress, PersonAddressInfo>).ToList();

                return FindAllQueryResponse<IList<PersonAddressInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<PersonAddressInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
