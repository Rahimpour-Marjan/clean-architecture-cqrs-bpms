using Application.EducationSubFieldApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.EducationSubFieldApplication.Commands
{
    public class EducationSubFieldCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("EducationSubField", "Handle")]
        public async void InputEducationSubField_Created_ReturnId()
        {
            //Arrage
            var educationSubFieldRepositoryMock = new Mock<IEducationSubFieldRepository>();

            var createEducationSubFieldCommand = new EducationSubFieldCreate.Command
            {
                Title = "دیپلم",
                EducationFieldId = 1000,
                CreatorId = 1000,
            };

            var createEducationSubFieldCommandHandler = new EducationSubFieldCreate.Handler(_uow);

            //Act
            var result = await createEducationSubFieldCommandHandler.Handle(createEducationSubFieldCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.EducationSubFieldId >= 0);
            //educationSubFieldRepositoryMock.Verify(ur => ur.Create(It.IsAny<EducationSubField>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
