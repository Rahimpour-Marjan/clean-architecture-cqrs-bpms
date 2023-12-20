using Moq;
using UnitTest.Common;
using Domain;
using Application.AccountCheckApplication.Commands;

namespace Test.Application.AccountCheckApplication.Commands
{
    public class CreateAccountCheckCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("AccountCheck", "Handle")]
        public async void InputAccountCheck_Created_ReturnId()
        {
            //Arrage
            var accountCheckRepositoryMock = new Mock<IAccountCheckRepository>();

            var createAccountCheckCommand = new AccountCheckCreate.Command
            {
                AccountId = 10000,
                CheckNumber = "15242",
                BankId = 1000,
                BranchName = "شعبه 1",
                Amount = 1000000000,
                PayTo = "مرجانه رحیم پور",
                IssueDate = DateTime.Now,
                ReceiptDate = DateTime.Now,
                ReturnDate = null,
                FrontImageUrl = "",
                BackImageUrl = "",
                SignatureUrl = null,
            };

            var createAccountCheckCommandHandler = new AccountCheckCreate.Handler(_uow);

            //Act
            var result = await createAccountCheckCommandHandler.Handle(createAccountCheckCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.AccountCheckId >= 0);
            //accountCheckRepositoryMock.Verify(ur => ur.Create(It.IsAny<AccountCheck>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
