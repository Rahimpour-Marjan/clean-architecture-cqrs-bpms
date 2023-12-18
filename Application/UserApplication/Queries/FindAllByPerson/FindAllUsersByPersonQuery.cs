using MediatR;
namespace Application.User.Queries.FindAllByAccount
{
    public class FindAllUsersByAccountQuery : IRequest<IList<Domain.User>>
    {
        public int AccountId { get; set; }
    }
}
