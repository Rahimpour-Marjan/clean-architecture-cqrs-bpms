using AutoMapper;
using MediatR;
using System.Data;
using Application.EducationSubFieldApplication.Models;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Domain.Resources;

namespace Application.EducationSubFieldApplication.Queries.FindAll
{
    public class FindAllEducationSubFieldQueryHandler : IRequestHandler<FindAllEducationSubFieldQuery, FindAllQueryResponse<IList<EducationSubFieldInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllEducationSubFieldQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<EducationSubFieldInfo>>> Handle(FindAllEducationSubFieldQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.EducationSubFieldRepository.FindAll(queryFilter, request.EducationFieldId);
                var result = model.Item1.Select(_mapper.Map<Domain.EducationSubField, EducationSubFieldInfo>).ToList();

                return FindAllQueryResponse<IList<EducationSubFieldInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<EducationSubFieldInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
