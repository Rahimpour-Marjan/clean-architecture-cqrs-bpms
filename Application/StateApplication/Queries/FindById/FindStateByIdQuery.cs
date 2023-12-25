using Application.StateApplication.Models;
using MediatR;

namespace Application.StateApplication.Queries.FindById
{
    public class FindStateByIdQuery : IRequest<StateInfo>
    {
        public int Id { get; set; }
    }
}
