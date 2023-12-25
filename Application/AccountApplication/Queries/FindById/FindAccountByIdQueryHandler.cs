using AutoMapper;
using MediatR;
using Infrastructure.Persistance;
using Application.Account.Models;
using Infrastructure.Persistance.Repositories;
using Domain;

namespace Application.Account.Queries.FindById
{
    internal class FindAccountByIdQueryHandler : IRequestHandler<FindAccountByIdQuery, AccountInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAccountByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<AccountInfo> Handle(FindAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.AccountRepository.FindById(request.Id);
            var result = _mapper.Map<Domain.Account, AccountInfo>(model);
            if (result != null)
            {
                var tempPost = model.AccountJuncPosts.Select(x => x.Post);
                result.Posts = tempPost.ToList();
            }
            return result;
        }
    }
}