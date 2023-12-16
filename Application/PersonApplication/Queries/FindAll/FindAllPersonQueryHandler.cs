using AutoMapper;
using MediatR;
using System.Data;
using Application.Person.Models;
using Infrastructure.Persistance.Repositories;
using Application.Common;
using Domain.Resources;

namespace Application.Person.Queries.FindAll
{
    public class FindAllPersonQueryHandler : IRequestHandler<FindAllPersonQuery, FindAllQueryResponse<IList<PersonInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllPersonQueryHandler( IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<PersonInfo>>> Handle(FindAllPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.PersonRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Person, PersonInfo>).ToList();
                if (result != null)
                {
                    int i = 0;
                    foreach (var item in result)
                    {
                        var tempPost = model.Item1[i].PersonJuncPosts.Select(x => x.Post);
                        item.Posts = tempPost.ToList();
                        i++;
                    }
                }
                return FindAllQueryResponse<IList<PersonInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<PersonInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
