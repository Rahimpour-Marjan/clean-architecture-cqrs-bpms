using Application.Common;
using Application.CreditPaymentApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.CreditPaymentApplication.Queries.FindAll
{
    public class FindAllCreditPaymentQueryHandler : IRequestHandler<FindAllCreditPaymentQuery, FindAllQueryResponse<IList<CreditPaymentInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllCreditPaymentQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<CreditPaymentInfo>>> Handle(FindAllCreditPaymentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.CreditPaymentRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.CreditPayment, CreditPaymentInfo>).ToList();

                return FindAllQueryResponse<IList<CreditPaymentInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<CreditPaymentInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
