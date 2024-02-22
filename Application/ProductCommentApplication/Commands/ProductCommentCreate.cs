using Application.Common;
using Domain;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ProductCommentApplication.Commands
{
    public class ProductCommentCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
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
                var ProductComment = new ProductComment(request.Title,request.ProductId, request.ProductCommentParentId, request.Approved, request.NameFamily, request.EmailAddress, request.Body, request.AnswerString,request.AnswerDatetime,request.Rate, request.CreatorId);
                try
                {
                    var newProductCommentId = await _uow.ProductCommentRepository.Create(ProductComment);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            ProductCommentId = newProductCommentId
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
