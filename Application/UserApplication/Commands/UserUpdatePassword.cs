using Application.Common;
using Application.LoginApplication.Interfaces;
using Infrastructure.Persistance.Repositories;
using MediatR;
using Domain.Enums;
using CryptoHashVerify;

namespace Application.User.Commands
{
    public class UserUpdatePassword
    {
        public class Command : IRequest<OperationResult<Response>>, ICommittableRequest
        {
            public int UserId { get; set; }
            public string OldPassword { get; set; }
            public string Password { get; set; }
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
                var user = await _uow.UserRepository.FindById(request.UserId);
                if (user == null)
                    return OperationResult<Response>.BuildFailure(Enum_Message.ITEMNOTFOUND);

                var checkPassword=CheckPasswordValidation<Response>.CheckPassword(request.Password);
                if (!checkPassword.Success)
                    return OperationResult<Response>.BuildFailure(checkPassword.ErrorMessage);

                var oldPassIsTrue = HashVerify.VerifyHashString(user.Password, user.Salt, request.OldPassword);

                if (!oldPassIsTrue)
                    return OperationResult<Response>.BuildFailure("پسورد فعلی صحیح نمی باشد.");

                var (hashedPassword, salt) = _authentication.GenerateHashPasswordAndSalt(request.Password);

                

                user.Password = hashedPassword;
                user.Salt = salt;

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
