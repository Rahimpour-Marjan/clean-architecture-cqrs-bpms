using static Application.LoginApplication.Commands.Login;

namespace Application.LoginApplication.Interfaces
{
    public interface IAuthentication
    {
        Task<Response> LoginAsync(Command user);
        (string, string) GenerateHashPasswordAndSalt(string password);

        //Task<AuthenticationResponse> RegisterAsync(CreateUserCommand user);
    }
}
