using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.User.Queries.FindAllUserGroups
{
    public class FindAllUserGroupsQueryHandler : IRequestHandler<FindAllUserGroupsQuery, IList<Tree>>
    {
        private readonly IUnitOfWork _uow;
        public FindAllUserGroupsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IList<Tree>> Handle(FindAllUserGroupsQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserGroupRepository.FindAllByUserId(request.UserId);

            return model;
        }
    }
}
