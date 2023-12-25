using Application.Notification.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.Notification.Queries.FindById
{
    internal class FindNotificationByIdQueryHandler : IRequestHandler<FindNotificationByIdQuery, NotificationInfo>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindNotificationByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<NotificationInfo> Handle(FindNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.NotificationRepository.FindById(request.Id, request.UserId);
            return _mapper.Map<Domain.Notification, NotificationInfo>(model);
        }
    }
}

