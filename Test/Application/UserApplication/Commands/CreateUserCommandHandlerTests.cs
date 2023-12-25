using Application.LoginApplication.Interfaces;
using Application.User.Commands;
using Infrastructure.Persistance.Repositories;
using Moq;
using UnitTest.Common;

namespace Test.Application.UserApplication.Commands
{
    public class CreateUserCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("CreateUser", "Handle")]
        public async void InputUser_Created_ReturnId()
        {
            //Arrage
            var userRepositoryMock = new Mock<IUserRepository>();
            var authserviceMock = new Mock<IAuthentication>();

            var createUserCommand = new UserCreate.Command
            {
                UserName = "Test",
                Password = "1234",
                AccountId = 1,
            };

            var createUserCommandHandler = new UserCreate.Handler(_uow, authserviceMock.Object);

            //Act
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.UserId >= 0);
            //userRepositoryMock.Verify(ur => ur.Create(It.IsAny<User>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
