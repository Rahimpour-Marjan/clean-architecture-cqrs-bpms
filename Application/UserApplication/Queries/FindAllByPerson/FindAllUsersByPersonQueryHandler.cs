using MediatR;
using Infrastructure.Persistance.Repositories;

namespace Application.User.Queries.FindAllByPerson
{
    public class FindAllUsersByPersonQueryHandler : IRequestHandler<FindAllUsersByPersonQuery, IList<Domain.User>>
    {
        private readonly IUnitOfWork _uow;
        public FindAllUsersByPersonQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IList<Domain.User>> Handle(FindAllUsersByPersonQuery request, CancellationToken cancellationToken)
        {
                var model = await _uow.UserRepository.FindAllByPerson(request.PersonId);

                return model.ToList();
        }
    }
}
