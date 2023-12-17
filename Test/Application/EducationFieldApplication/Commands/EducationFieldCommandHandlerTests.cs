using Moq;
using UnitTest.Common;
using Domain;
using Application.EducationFieldApplication.Commands;

namespace Test.Application.EducationFieldApplication.Commands
{
    public class EducationFieldEducationFieldCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("EducationField", "Handle")]
        public async void InputEducationField_Created_ReturnId()
        {
            //Arrage
            var educationFieldRepositoryMock = new Mock<IEducationFieldRepository>();

            var createEducationFieldCommand = new EducationFieldCreate.Command
            {
                Title="دیپلم",
            };

            var createEducationFieldCommandHandler = new EducationFieldCreate.Handler(_uow);

            //Act
            var result = await createEducationFieldCommandHandler.Handle(createEducationFieldCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.EducationFieldId >= 0);
            //educationFieldRepositoryMock.Verify(ur => ur.Create(It.IsAny<EducationField>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
