using Application.BankApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.BankApplication.Commands
{
    public class CreateBankCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Bank", "Handle")]
        public async void InputBank_Created_ReturnId()
        {
            //Arrage
            var bankRepositoryMock = new Mock<IBankRepository>();

            var createBankCommand = new BankCreate.Command
            {
                Title = "ایران",
                IsActive = true,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createBankCommandHandler = new BankCreate.Handler(_uow);

            //Act
            var result = await createBankCommandHandler.Handle(createBankCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.BankId >= 0);
            //bankRepositoryMock.Verify(ur => ur.Create(It.IsAny<Bank>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
