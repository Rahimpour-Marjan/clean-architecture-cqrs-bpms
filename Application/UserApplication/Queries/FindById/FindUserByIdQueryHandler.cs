using AutoMapper;
using MediatR;
using Application.Users.Models;
using Infrastructure.Persistance.Repositories;

namespace Application.User.Queries.FindById
{
    class FindUserByIdQueryHandler : IRequestHandler<FindUserByIdQuery, UserInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UserInfo> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserRepository.FindById(request.Id);

            var result = _mapper.Map<Domain.User, UserInfo>(model);

            var userPost = "";
            if (model.Person != null)
            {
                var post = model.Person.PersonJuncPosts.Select(x => x.Post).FirstOrDefault();
                if (post != null)
                    userPost = post.Title;

                result.Post = userPost;
                var tempPost = model.Person.PersonJuncPosts.Select(x => x.Post);
                result.Person.Posts = tempPost.ToList();

            }


            return result;
        }
    }
}
