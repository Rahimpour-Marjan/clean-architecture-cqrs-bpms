using Moq;
using UnitTest.Common;
using Domain;
using Application.CountryApplication.Commands;

namespace Test.Application.CountryApplication.Commands
{
    public class CreateCountryCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Country", "Handle")]
        public async void InputCountry_Created_ReturnId()
        {
            //Arrage
            var countryRepositoryMock = new Mock<ICountryRepository>();

            var createCountryCommand = new CountryCreate.Command
            {
                Title="ایران",
                Code="01",
                ZipCode="0098",
                PostalCode="1369",
                LocationLong = "",
                LocationLat = "",
                ImageUrl="",
            };

            var createCountryCommandHandler = new CountryCreate.Handler(_uow);

            //Act
            var result = await createCountryCommandHandler.Handle(createCountryCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.CountryId >= 0);
            //countryRepositoryMock.Verify(ur => ur.Create(It.IsAny<Country>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
