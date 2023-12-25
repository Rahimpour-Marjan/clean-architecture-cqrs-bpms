using Application.Common;
using Application.Users.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.User.Queries.FindAll
{
    public class FindAllUsersQueryHandler : IRequestHandler<FindAllUsersQuery, FindAllQueryResponse<IList<UserInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<UserInfo>>> Handle(FindAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.UserRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.User, UserInfo>).ToList();

                if (result != null)
                {
                    int i = 0;
                    foreach (var item in result)
                    {
                        var tempPost = model.Item1[i].Account.AccountJuncPosts.Select(x => x.Post);
                        item.Account.Posts = tempPost.ToList();
                        i++;
                    }
                }

                return FindAllQueryResponse<IList<UserInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<UserInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
