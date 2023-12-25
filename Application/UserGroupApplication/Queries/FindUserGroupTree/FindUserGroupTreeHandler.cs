using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserGroupApplication.Queries.FindUserGroupTree
{
    class FindUserGroupTreeHandler : IRequestHandler<FindUserGroupTreeQuery, IList<Tree>>
    {
        private readonly IUnitOfWork _uow;

        public FindUserGroupTreeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IList<Tree>> Handle(FindUserGroupTreeQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserGroupRepository.FindUserGroupTree();
            return model;
        }
    }
}
