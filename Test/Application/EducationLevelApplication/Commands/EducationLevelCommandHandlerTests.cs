using Moq;
using UnitTest.Common;
using Domain;
using Application.EducationLevelApplication.Commands;

namespace Test.Application.EducationLevelApplication.Commands
{
    public class EducationLevelEducationLevelCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("EducationLevel", "Handle")]
        public async void InputEducationLevel_Created_ReturnId()
        {
            //Arrage
            var educationLevelRepositoryMock = new Mock<IEducationLevelRepository>();

            var createEducationLevelCommand = new EducationLevelCreate.Command
            {
                Title="دیپلم",
            };

            var createEducationLevelCommandHandler = new EducationLevelCreate.Handler(_uow);

            //Act
            var result = await createEducationLevelCommandHandler.Handle(createEducationLevelCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.EducationLevelId >= 0);
            //educationLevelRepositoryMock.Verify(ur => ur.Create(It.IsAny<EducationLevel>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
