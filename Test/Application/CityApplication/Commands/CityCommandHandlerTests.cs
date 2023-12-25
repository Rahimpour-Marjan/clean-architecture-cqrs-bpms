using Moq;
using UnitTest.Common;
using Domain;
using Application.CityApplication.Commands;

namespace Test.Application.CityApplication.Commands
{
    public class CreateCityCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("City", "Handle")]
        public async void InputCity_Created_ReturnId()
        {
            //Arrage
            var cityRepositoryMock = new Mock<ICityRepository>();

            var createCityCommand = new CityCreate.Command
            {
                Title="تهران",
                StateId=1000,
                Code="01",
                ZipCode="021",
                PostalCode="1369",
                LocationLong = "",
                LocationLat = "",
                ImageUrl="",
            };

            var createCityCommandHandler = new CityCreate.Handler(_uow);

            //Act
            var result = await createCityCommandHandler.Handle(createCityCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.CityId >= 0);
            //cityRepositoryMock.Verify(ur => ur.Create(It.IsAny<City>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
