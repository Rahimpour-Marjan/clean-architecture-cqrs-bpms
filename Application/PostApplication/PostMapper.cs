using Application.Post.Models;
using AutoMapper;

namespace Application.Post
{
    internal class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Domain.Post, PostInfo>();
        }
    }
}
