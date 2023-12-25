using Application.Menu.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Menu.Queries.FindById
{
    internal class FindMenuByIdQueryHandler : IRequestHandler<FindMenuByIdQuery, MenuInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindMenuByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<MenuInfo> Handle(FindMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.MenuRepository.FindById(request.Id);
            return _mapper.Map<Domain.Menu, MenuInfo>(model);
        }
    }
}
