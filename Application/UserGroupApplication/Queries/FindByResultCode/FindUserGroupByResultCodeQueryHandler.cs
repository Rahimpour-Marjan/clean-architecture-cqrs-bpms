using MediatR;
using Infrastructure.Persistance.Repositories;

namespace Application.UserGroup.Queries.FindByResultCode
{
    internal class FindUserGroupByResultCodeQueryHandler : IRequestHandler<FindUserGroupByResultCodeQuery, Domain.UserGroup>
    {
        private readonly IUnitOfWork _uow;
        public FindUserGroupByResultCodeQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Domain.UserGroup> Handle(FindUserGroupByResultCodeQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserGroupRepository.FindByResultCode(request.ResultCode);
            return model;
        }
    }
}
