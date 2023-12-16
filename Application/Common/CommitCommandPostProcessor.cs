using MediatR.Pipeline;
using Infrastructure.Persistance;
using MediatR;

namespace Application.Common
{
    public class CommitCommandPostProcessor<TRequest, TResponse>
        : IRequestPostProcessor<TRequest, TResponse> where TRequest : IRequest<TResponse>

    {
        private readonly MakmonDbContext _db;
        public CommitCommandPostProcessor(MakmonDbContext db)
        {
            _db = db;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (request is ICommittableRequest)
            {
                await _db.SaveChangesAsync();
            }
            //return await next();
        }
    }
}
