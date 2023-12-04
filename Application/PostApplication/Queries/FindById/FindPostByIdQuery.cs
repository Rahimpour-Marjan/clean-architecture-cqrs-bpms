using MediatR;
using Application.Post.Models;

namespace Application.Post.Queries.FindById
{
    public class FindPostByIdQuery : IRequest<PostInfo>
    {
        public int Id { get; set; }

    }
}
