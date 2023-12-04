using AutoMapper;
using MediatR;
using System.Data;
using Application.Notification.Models;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Domain.Resources;

namespace Application.Notification.Queries.FindAll
{
    internal class FindAllNotificationQueryHandler : IRequestHandler<FindAllNotificationQuery, FindAllQueryResponse<IList<NotificationInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllNotificationQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<NotificationInfo>>> Handle(FindAllNotificationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.NotificationRepository.FindAll(queryFilter,request.UserId);
                var result = model.Item1.Select(_mapper.Map<Domain.Notification, NotificationInfo>).ToList();

                return FindAllQueryResponse<IList<NotificationInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<NotificationInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}

