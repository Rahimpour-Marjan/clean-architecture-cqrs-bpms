using MediatR;
using Infrastructure.Persistance.Repositories;
using Domain.Resources;

namespace Application.UserGroup.Queries.FindFormTree
{
    class FindAllFormTreeHandler : IRequestHandler<FindAllFormTreeQuery, List<AccessTree?>>
    {
        private readonly IUnitOfWork _uow;
        
        public FindAllFormTreeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<AccessTree?>> Handle(FindAllFormTreeQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserGroupRepository.FindTree(request.UserId,request.UserGroupId, request.PostId, request.IsSelected);

            return model;
        }
    }
}
