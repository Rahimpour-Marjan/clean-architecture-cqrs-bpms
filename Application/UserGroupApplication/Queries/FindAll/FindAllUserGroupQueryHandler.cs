using Application.Common;
using Application.UserGroup.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.UserGroup.Queries.FindAll
{
    internal class FindAllUserGroupQueryHandler : IRequestHandler<FindAllUserGroupQuery, FindAllQueryResponse<IList<UserGroupInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllUserGroupQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<UserGroupInfo>>> Handle(FindAllUserGroupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.UserGroupRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.UserGroup, UserGroupInfo>).ToList();

                return FindAllQueryResponse<IList<UserGroupInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<UserGroupInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
