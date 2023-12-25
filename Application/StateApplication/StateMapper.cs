using Application.StateApplication.Models;
using AutoMapper;
using Domain;

namespace Application.StateApplication
{
    internal class StateMapper : Profile
    {
        public StateMapper()
        {
            CreateMap<State, StateInfo>();
        }
    }
}
