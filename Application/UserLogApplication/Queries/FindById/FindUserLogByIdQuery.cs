using Application.UserLogApplication.Models;
using MediatR;

namespace Application.UserLogApplication.Queries.FindById
{
    public class FindUserLogByIdQuery : IRequest<UserLogInfo>
    {
        public int Id { get; set; }
    }
}
