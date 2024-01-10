using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ArticleApplication.Commands
{
    public class ArticleCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string Title { get; set; }
            public int CategoryId { get; set; }
            public string? Keywords { get; set; }
            public string Summary { get; set; }
            public string Body { get; set; }
            public int VisitCount { get; set; }
            public bool? IsSlider { get; set; }
            public bool Active { get; set; }
            public string? Url { get; set; }
            public string? H1 { get; set; }
            public string? Writer { get; set; }
            public string? WriterPosition { get; set; }
            public string? WriterImageUrl { get; set; }
            public string? Aparat { get; set; }
            public string? Canonical { get; set; }
            public bool? NoFollow { get; set; }
            public bool? NoIndex { get; set; }
            public string? PostLabel { get; set; }
            public string? ImageUrl { get; set; }
            public DateTime? ShowDateTime { get; set; }
            public DateTime? ExpireDateTime { get; set; }
            public int CreatorId { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.CategoryId, request.Keywords, request.Summary, request.Body, request.VisitCount, request.IsSlider, request.Active, request.Url, request.H1, request.Writer,
                    request.WriterPosition, request.WriterImageUrl, request.Aparat, request.Canonical, request.NoFollow, request.NoIndex, request.PostLabel, request.ImageUrl, request.ShowDateTime, request.ExpireDateTime, request.CreatorId);
                try
                {
                    var newArticleId = await _uow.ArticleRepository.Create(article);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ArticleId = newArticleId
                        });
                    await Task.CompletedTask;
                    return result;
                }
                catch (Exception ex)
                {

                    var exResult = OperationResult<Response>.BuildFailure(ex);
                    return exResult;
                }
            }
        }

        public class Response
        {
            public int ArticleId { get; set; }
        }
    }
}
