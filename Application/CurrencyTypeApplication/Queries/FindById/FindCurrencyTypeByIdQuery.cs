using MediatR;
using Application.CurrencyTypeApplication.Models;

namespace Application.CurrencyTypeApplication.Queries.FindById
{
    public class FindCurrencyTypeByIdQuery : IRequest<CurrencyTypeInfo>
    {
        public int Id { get; set; }
    }
}
