using Application.ZoneApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ZoneApplication.Commands
{
    public class CreateZoneCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Zone", "Handle")]
        public async void InputZone_Created_ReturnId()
        {
            //Arrage
            var zoneRepositoryMock = new Mock<IZoneRepository>();

            var createZoneCommand = new ZoneCreate.Command
            {
                Title = "منطقه 1",
                CityId = 1000,
                Code = "01",
                ZipCode = "021",
                PostalCode = "1369",
                LocationLong = "",
                LocationLat = "",
                ImageUrl = "",
            };

            var createZoneCommandHandler = new ZoneCreate.Handler(_uow);

            //Act
            var result = await createZoneCommandHandler.Handle(createZoneCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ZoneId >= 0);
            //zoneRepositoryMock.Verify(ur => ur.Create(It.IsAny<Zone>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
