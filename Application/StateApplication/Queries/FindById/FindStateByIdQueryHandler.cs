using Application.StateApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.StateApplication.Queries.FindById
{
    class FindStateByIdQueryHandler : IRequestHandler<FindStateByIdQuery, StateInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindStateByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<StateInfo> Handle(FindStateByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.StateRepository.FindById(request.Id);
            return _mapper.Map<Domain.State, StateInfo>(model);
        }
    }
}
