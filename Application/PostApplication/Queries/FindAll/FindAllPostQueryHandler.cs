using Application.Common;
using Application.Post.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.Post.Queries.FindAll
{
    internal class FindAllPostQueryHandler : IRequestHandler<FindAllPostQuery, FindAllQueryResponse<IList<PostInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly MakmonDbContext _db;
        public FindAllPostQueryHandler(MakmonDbContext db, IUnitOfWork uow, IMapper mapper)
        {
            _db = db;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<PostInfo>>> Handle(FindAllPostQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.PostRepository.FindAll(queryFilter, request.ParentId);
                var result = model.Item1.Select(_mapper.Map<Domain.Post, PostInfo>).ToList();

                return FindAllQueryResponse<IList<PostInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<PostInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
