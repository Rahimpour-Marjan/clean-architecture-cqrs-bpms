using Application.Common;
using Application.LoginApplication.Interfaces;
using MediatR;

namespace Application.LoginApplication.Commands
{
    public class Login
    {
        public class Command : IRequest<OperationResult<Response>>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult<Response>>
        {
            private readonly IAuthentication _authentication;
            public Handler(IAuthentication authentication) => _authentication = authentication;

            public async Task<OperationResult<Response>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var loginResult = await _authentication.LoginAsync(request);
                    var result = OperationResult<Response>
                            .BuildSuccessResult(new Response
                            {
                                IsSuccess = loginResult.IsSuccess,
                                Token = loginResult.Token,
                                Errors = loginResult.Errors
                            });
                    await Task.CompletedTask;
                    return result;                    //}
                    //else
                    //{
                    //    var result = OperationResult<Response>
                    //           .BuildFailure(loginResult.Errors);
                    //    await Task.CompletedTask;
                    //    return result;
                    //}
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
            public bool IsSuccess { get; set; }
            public string Token { get; set; }
            public string[] Errors { get; set; }
        }
    }
}
