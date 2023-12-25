using MediatR;
using Application.StateApplication.Models;

namespace Application.StateApplication.Queries.FindById
{
    public class FindStateByIdQuery : IRequest<StateInfo>
    {
        public int Id { get; set; }
    }
}
