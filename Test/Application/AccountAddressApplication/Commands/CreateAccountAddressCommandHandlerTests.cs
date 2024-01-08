using Application.AccountAddressApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountAddressApplication.Commands
{
    public class CreateAccountAddressCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("AccountAddress", "Handle")]
        public async void InputAccountAddress_Created_ReturnId()
        {
            //Arrage
            var accountAddressRepositoryMock = new Mock<IAccountAddressRepository>();

            var createAccountAddressCommand = new AccountAddressCreate.Command
            {
                AccountId = 1000,
                Title = "آدرس من",
                FullName = "مرجانه رحیم پور",
                Phone = "09302161127",
                ExtraPhone = null,
                CountryId = 1000,
                StateId = 1000,
                CityId = 1000,
                ZoneId = 1000,
                Address = "آدرس 400 کارکتری من",
                ZipCode = "0098",
                PostalCode = "1369587957",
                LocationLat = "",
                LocationLong = "",
                CreatorId=1000,
            };

            var createAccountAddressCommandHandler = new AccountAddressCreate.Handler(_uow);

            //Act
            var result = await createAccountAddressCommandHandler.Handle(createAccountAddressCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.AccountAddressId >= 0);
            //accountAddressRepositoryMock.Verify(ur => ur.Create(It.IsAny<AccountAddress>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
