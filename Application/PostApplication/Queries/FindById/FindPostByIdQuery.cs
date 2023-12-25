using Application.Post.Models;
using MediatR;

namespace Application.Post.Queries.FindById
{
    public class FindPostByIdQuery : IRequest<PostInfo>
    {
        public int Id { get; set; }

    }
}
