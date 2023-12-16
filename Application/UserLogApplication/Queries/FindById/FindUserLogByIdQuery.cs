using MediatR;
using Application.UserLogApplication.Models;

namespace Application.UserLogApplication.Queries.FindById
{
    public class FindUserLogByIdQuery : IRequest<UserLogInfo>
    {
        public int Id { get; set; }
    }
}
