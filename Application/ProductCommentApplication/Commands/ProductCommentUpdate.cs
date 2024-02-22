using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCommentApplication.Commands
{
    public class ProductCommentUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int ProductCommentId { get; set; }
            public string Title { get; set; }
            public int ProductId { get; set; }
            public int? ProductCommentParentId { get; set; }
            public bool Approved { get; set; }
            public string NameFamily { get; set; }
            public string EmailAddress { get; set; }
            public string Body { get; set; }
            public string? AnswerString { get; set; }
            public DateTime? AnswerDatetime { get; set; }
            public double? Rate { get; set; }
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
                var ProductComment = await _uow.ProductCommentRepository.FindById(request.ProductCommentId);
                if (ProductComment == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);
                ProductComment.Title = request.Title;
                ProductComment.ProductId = request.ProductId;
                ProductComment.ProductCommentParentId = request.ProductCommentParentId;
                ProductComment.Approved = request.Approved;
                ProductComment.NameFamily = request.NameFamily;
                ProductComment.EmailAddress = request.EmailAddress;
                ProductComment.Body = request.Body;
                ProductComment.AnswerString = request.AnswerString;
                ProductComment.AnswerDatetime = request.AnswerDatetime;
                ProductComment.Rate = request.Rate;
                ProductComment.ModifireId = request.ModifireId;
                ProductComment.ModifiedDate = DateTime.Now;

                try
                {
                    await _uow.ProductCommentRepository.Update(ProductComment);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductCommentId = request.ProductCommentId
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
            public int ProductCommentId { get; set; }
        }
    }
}
