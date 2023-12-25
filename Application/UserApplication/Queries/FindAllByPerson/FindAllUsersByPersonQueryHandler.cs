using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.User.Queries.FindAllByAccount
{
    public class FindAllUsersByAccountQueryHandler : IRequestHandler<FindAllUsersByAccountQuery, IList<Domain.User>>
    {
        private readonly IUnitOfWork _uow;
        public FindAllUsersByAccountQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IList<Domain.User>> Handle(FindAllUsersByAccountQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserRepository.FindAllByAccount(request.AccountId);

            return model.ToList();
        }
    }
}
