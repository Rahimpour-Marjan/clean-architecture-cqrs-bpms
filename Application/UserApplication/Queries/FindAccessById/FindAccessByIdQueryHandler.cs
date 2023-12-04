using AutoMapper;
using MediatR;
using Application.Users.Models;
using Infrastructure.Persistance.Repositories;
using Domain;
using Application.SiteActionApplication.Models;

namespace Application.User.Queries.FindAccessById
{
    class FindAccessByIdQueryHandler : IRequestHandler<FindAccessByIdQuery, IList<SiteActionInfo>?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAccessByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IList<SiteActionInfo>?> Handle(FindAccessByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserRepository.FindAccess(request.Id);
            var result = model.Select(_mapper.Map<Domain.SiteAction, SiteActionInfo>).ToList();

            return result;
        }
    }
}
