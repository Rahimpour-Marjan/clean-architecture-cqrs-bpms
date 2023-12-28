using Application.StateApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.StateApplication.Commands
{
    public class CreateStateCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("State", "Handle")]
        public async void InputState_Created_ReturnId()
        {
            //Arrage
            var stateRepositoryMock = new Mock<IStateRepository>();

            var createStateCommand = new StateCreate.Command
            {
                Title = "تهران",
                CountryId = 1000,
                Code = "01",
                ZipCode = "021",
                PostalCode = "1369",
                LocationLong = "",
                LocationLat = "",
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createStateCommandHandler = new StateCreate.Handler(_uow);

            //Act
            var result = await createStateCommandHandler.Handle(createStateCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.StateId >= 0);
            //stateRepositoryMock.Verify(ur => ur.Create(It.IsAny<State>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
