using AutoMapper;
using MediatR;
using Application.UserGroup.Models;
using Infrastructure.Persistance.Repositories;

namespace Application.UserGroup.Queries.FindById
{
    internal class FindUserGroupByIdQueryHandler : IRequestHandler<FindUserGroupByIdQuery, UserGroupInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindUserGroupByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UserGroupInfo> Handle(FindUserGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserGroupRepository.FindById(request.Id);
            return _mapper.Map<Domain.UserGroup, UserGroupInfo>(model);
        }
    }
}
