using Moq;
using UnitTest.Common;
using Domain;
using Application.PersonAddressApplication.Commands;

namespace Test.Application.PersonAddressApplication.Commands
{
    public class CreatePersonAddressCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("PersonAddress", "Handle")]
        public async void InputPersonAddress_Created_ReturnId()
        {
            //Arrage
            var personAddressRepositoryMock = new Mock<IPersonAddressRepository>();

            var createPersonAddressCommand = new PersonAddressCreate.Command
            {
                PersonId = 1000,
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
            };

            var createPersonAddressCommandHandler = new PersonAddressCreate.Handler(_uow);

            //Act
            var result = await createPersonAddressCommandHandler.Handle(createPersonAddressCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.PersonAddressId >= 0);
            //personAddressRepositoryMock.Verify(ur => ur.Create(It.IsAny<PersonAddress>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
