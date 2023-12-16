using AutoMapper;
using MediatR;
using Application.Post.Models;
using Infrastructure.Persistance.Repositories;
using Domain;

namespace Application.Post.Queries.FindById
{
    internal class FindPostByIdQueryHandler : IRequestHandler<FindPostByIdQuery, PostInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindPostByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PostInfo> Handle(FindPostByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.PostRepository.FindById(request.Id);
            var result = _mapper.Map<Domain.Post, PostInfo>(model);
          
            return result;
        }
    }
}
