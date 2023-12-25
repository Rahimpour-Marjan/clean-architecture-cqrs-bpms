using Application.UserLogApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UserLogApplication.Queries.FindById
{
    class FindUserLogByIdQueryHandler : IRequestHandler<FindUserLogByIdQuery, UserLogInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindUserLogByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<UserLogInfo> Handle(FindUserLogByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.UserLogRepository.FindById(request.Id);
            return _mapper.Map<Domain.UserLog, UserLogInfo>(model);
        }
    }
}
