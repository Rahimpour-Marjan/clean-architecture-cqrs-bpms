using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;

namespace Application.Menu.Queries.FindAll
{
    internal class FindAllMenuQueryHandler : IRequestHandler<FindAllMenuQuery, List<Domain.Resources.Menu?>>
    {
        private readonly IUnitOfWork _uow;
        public FindAllMenuQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<Domain.Resources.Menu?>> Handle(FindAllMenuQuery request, CancellationToken cancellationToken)
        {
            return await _uow.MenuRepository.FindAll();
        }
    }
}
