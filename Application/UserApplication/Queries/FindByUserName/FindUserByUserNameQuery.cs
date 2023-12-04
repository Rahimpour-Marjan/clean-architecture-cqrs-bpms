using MediatR;
using Application.Users.Models;
using Infrastructure.Persistance.Repositories;
using AutoMapper;
using Domain;

namespace Application.User.Queries.FindByAuthInfo
{
    public class FindUserByUserNameQuery : IRequest<UserInfo>
    {
        public string UserName { get; set; }
    }

    public class FindUserByUserNameQueryHandler : IRequestHandler<FindUserByUserNameQuery, UserInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindUserByUserNameQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UserInfo> Handle(FindUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserRepository.FindByUserName(request.UserName);
            return _mapper.Map<Domain.User, UserInfo>(model);
        }
    }
}
