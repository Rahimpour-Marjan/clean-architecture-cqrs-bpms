using AutoMapper;
using MediatR;
using Application.Users.Models;
using Domain;
using Application.User.Queries.FindByAuthInfo;
using Infrastructure.Persistance.Repositories;

namespace Application.User.Queries.FindByLoginInfo
{
    class FindUserByAuthInfoQueryHandler : IRequestHandler<FindUserByAuthInfoQuery, UserInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindUserByAuthInfoQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UserInfo> Handle(FindUserByAuthInfoQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserRepository.FindByAuthInfo(request.UserName, request.Password);
            return _mapper.Map<Domain.User, UserInfo>(model);
        }
    }
}
