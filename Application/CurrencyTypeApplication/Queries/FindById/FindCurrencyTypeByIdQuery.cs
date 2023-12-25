using Application.CurrencyTypeApplication.Models;
using MediatR;

namespace Application.CurrencyTypeApplication.Queries.FindById
{
    public class FindCurrencyTypeByIdQuery : IRequest<CurrencyTypeInfo>
    {
        public int Id { get; set; }
    }
}
