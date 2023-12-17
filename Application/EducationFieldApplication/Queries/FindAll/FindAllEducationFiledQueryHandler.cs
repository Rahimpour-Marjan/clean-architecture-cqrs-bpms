using AutoMapper;
using MediatR;
using System.Data;
using Application.EducationFieldApplication.Models;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Domain.Resources;

namespace Application.EducationFieldApplication.Queries.FindAll
{
    public class FindAllEducationFiledQueryHandler : IRequestHandler<FindAllEducationFieldQuery, FindAllQueryResponse<IList<EducationFieldInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllEducationFiledQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<EducationFieldInfo>>> Handle(FindAllEducationFieldQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.EducationFieldRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.EducationField, EducationFieldInfo>).ToList();

                return FindAllQueryResponse<IList<EducationFieldInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<EducationFieldInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
