using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ArticleApplication.Commands
{
    public class ArticleUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ArticleId { get; set; }
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
            public int ModifireId { get; set; }
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
                var article = await _uow.ArticleRepository.FindById(request.ArticleId);
                if (article == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                article.Title = request.Title;
                article.CategoryId = request.CategoryId;
                article.Keywords = request.Keywords;
                article.Summary = request.Summary;
                article.Body = request.Body;
                article.VisitCount = request.VisitCount;
                article.IsSlider = request.IsSlider;
                article.Active = request.Active;
                article.Url = request.Url;
                article.H1 = request.H1;
                article.Writer = request.Writer;
                article.WriterPosition = request.WriterPosition;
                article.WriterImageUrl = request.WriterImageUrl;
                article.Aparat = request.Aparat;
                article.Canonical = request.Canonical;
                article.NoFollow = request.NoFollow;
                article.NoIndex = request.NoIndex;
                article.PostLabel = request.PostLabel;
                article.ImageUrl = request.ImageUrl;
                article.ShowDateTime = request.ShowDateTime;
                article.ExpireDateTime = request.ExpireDateTime;
                article.ModifireId = request.ModifireId;
                article.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ArticleRepository.Update(article);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ArticleId = request.ArticleId
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
