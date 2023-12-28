using Application.CurrencyTypeApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.CurrencyTypeApplication.Commands
{
    public class CreateCurrencyTypeCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("CurrencyType", "Handle")]
        public async void InputCurrencyType_Created_ReturnId()
        {
            //Arrage
            var currencyTypeRepositoryMock = new Mock<ICurrencyTypeRepository>();

            var createCurrencyTypeCommand = new CurrencyTypeCreate.Command
            {
                Title = "ریال",
                CurrencySign = "ریال",
                UnitPrice = 1000,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createCurrencyTypeCommandHandler = new CurrencyTypeCreate.Handler(_uow);

            //Act
            var result = await createCurrencyTypeCommandHandler.Handle(createCurrencyTypeCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.CurrencyTypeId >= 0);
            //currencyTypeRepositoryMock.Verify(ur => ur.Create(It.IsAny<CurrencyType>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
