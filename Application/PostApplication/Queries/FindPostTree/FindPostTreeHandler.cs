using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.PostApplication.Queries.FindPostTree
{
    class FindPostTreeHandler : IRequestHandler<FindPostTreeQuery, IList<Tree>>
    {
        private readonly IUnitOfWork _uow;

        public FindPostTreeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IList<Tree>> Handle(FindPostTreeQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.PostRepository.FindPostTree();
            return model;
        }
    }
}
