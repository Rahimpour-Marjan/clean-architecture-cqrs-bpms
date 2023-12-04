using AutoMapper;
using Application.Post.Models;

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
