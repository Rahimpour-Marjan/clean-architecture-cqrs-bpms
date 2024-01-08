using Application.CreditPaymentApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.CreditPaymentApplication.Commands
{
    public class CreateCreditPaymentCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("CreditPayment", "Handle")]
        public async void InputCreditPayment_Created_ReturnId()
        {
            //Arrage
            var creditPaymentRepositoryMock = new Mock<ICreditPaymentRepository>();

            var createCreditPaymentCommand = new CreditPaymentCreate.Command
            {
                AccountId = 1000,
                AccountCreditId = 1000,
                Status = Domain.Enums.PaymentStatus.UnPaid,
                RefNumber = "123456",
                ExternalInfo1 = null,
                ExternalInfo2 = null,
                Amount = 10000,
                IpAddress = "164.152.12.11",
                Description = "",
                CurrencyTypeId = 1000,
                IsInPlace = false,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createCreditPaymentCommandHandler = new CreditPaymentCreate.Handler(_uow);

            //Act
            var result = await createCreditPaymentCommandHandler.Handle(createCreditPaymentCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.CreditPaymentId >= 0);
            //creditPaymentRepositoryMock.Verify(ur => ur.Create(It.IsAny<CreditPayment>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
