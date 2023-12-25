using Application.Common;
using Application.LoginApplication.Interfaces;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.User.Commands
{
    public class UserCreate
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public int AccountId { get; set; }
            public int? ApiResultCode { get; set; }

        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private IUnitOfWork _uow;
            private IAuthentication _authentication;
            public Handler(IUnitOfWork uow, IAuthentication authentication)
            {
                _uow = uow;
                _authentication = authentication;
            }

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                var userIsExist = await _uow.UserRepository.FindByUserName(request.UserName);
                if (userIsExist != null)
                    return OperationResult<Response>.BuildFailure("نام کاربری تکراری می باشد.");
                var checkPassword = CheckPasswordValidation<Response>.CheckPassword(request.Password);
                if (!checkPassword.Success)
                    return OperationResult<Response>.BuildFailure(checkPassword.ErrorMessage);

                var Account = await _uow.AccountRepository.FindById(request.AccountId);
                if (Account == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                var (hashedPassword, salt) = _authentication.GenerateHashPasswordAndSalt(request.Password);
                //var user = new Domain.User(request.AccountId, request.UserName, hashedPassword, salt, Account.Email??"", UserType.DynamicUser, request.IsActive, request.ApiResultCode);
                try
                {
                    //var newUserId = await _uow.UserRepository.Create(user);

                    var result = OperationResult<Response>
                      .BuildSuccessResult(new Response
                      {
                          UserId = 0
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
