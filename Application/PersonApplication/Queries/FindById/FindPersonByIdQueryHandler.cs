using AutoMapper;
using MediatR;
using Infrastructure.Persistance;
using Application.Person.Models;
using Infrastructure.Persistance.Repositories;
using Domain;

namespace Application.Person.Queries.FindById
{
    internal class FindPersonByIdQueryHandler : IRequestHandler<FindPersonByIdQuery, PersonInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindPersonByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PersonInfo> Handle(FindPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.PersonRepository.FindById(request.Id);
            var result = _mapper.Map<Domain.Person, PersonInfo>(model);
            if (result != null)
            {
                var tempPost = model.PersonJuncPosts.Select(x => x.Post);
                result.Posts = tempPost.ToList();
            }
            return result;
        }
    }
}