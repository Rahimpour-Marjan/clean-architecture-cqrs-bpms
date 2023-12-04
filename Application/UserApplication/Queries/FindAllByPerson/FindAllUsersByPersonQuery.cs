using MediatR;
namespace Application.User.Queries.FindAllByPerson
{
    public class FindAllUsersByPersonQuery : IRequest<IList<Domain.User>>
    {
        public int PersonId { get; set; }
    }
}
