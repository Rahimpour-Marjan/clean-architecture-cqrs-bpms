using Application.AccountCreditApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountCreditApplication.Commands
{
    public class CreateAccountCreditCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("AccountCredit", "Handle")]
        public async void InputAccountCredit_Created_ReturnId()
        {
            //Arrage
            var accountCreditRepositoryMock = new Mock<IAccountCreditRepository>();

            var createAccountCreditCommand = new AccountCreditCreate.Command
            {
                AccountId = 10000,
                Description = "",
                Amount = 1000000000,
                Remain = 1000000000,
                AccountCheckId = null,
                IsActive = true,
                CreditType = Domain.Enums.CreditType.Deposit,
                CreatorId = 1000,
            };

            var createAccountCreditCommandHandler = new AccountCreditCreate.Handler(_uow);

            //Act
            var result = await createAccountCreditCommandHandler.Handle(createAccountCreditCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.AccountCreditId >= 0);
            //accountCreditRepositoryMock.Verify(ur => ur.Create(It.IsAny<AccountCredit>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
