using Application.Common;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.User.Commands
{
    public class UserUpdate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public bool IsActive { get; set; }
            public int AccountId { get; set; }
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
                var user = await _uow.UserRepository.FindById(request.UserId);
                if (user == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                var userIsExist = await _uow.UserRepository.FindByUserName(request.UserName);
                if (user.UserName != request.UserName && userIsExist != null)
                    return OperationResult<Response>.BuildFailure("نام کاربری تکراری می باشد.");

                var Account = await _uow.AccountRepository.FindById(request.AccountId);
                if (Account == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                user.UserName = request.UserName;
                user.IsActive = request.IsActive;
                user.Email = Account.Email ?? "";
                user.AccountId = request.AccountId;
                try
                {
                    await _uow.UserRepository.Update(user);
                    var result = OperationResult<Response>
                        .BuildSuccessResult(new Response
                        {
                            UserId = request.UserId
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
            public int UserId { get; set; }
        }
    }
}
