using Application.CategoryApplication.Commands;
using Domain;
using Domain.Enums;
using Moq;
using UnitTest.Common;

namespace Test.Application.CategoryApplication.Commands
{
    public class CreateCategoryCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Category", "Handle")]
        public async void InputCategory_Created_ReturnId()
        {
            //Arrage
            var categoryRepositoryMock = new Mock<ICategoryRepository>();

            var createCategoryCommand = new CategoryCreate.Command
            {
                Title = "تهران",
                Type = CategoryType.News,
                IsActive = true,
                Url = "تست",
                Body = "تست",
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createCategoryCommandHandler = new CategoryCreate.Handler(_uow);

            //Act
            var result = await createCategoryCommandHandler.Handle(createCategoryCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.CategoryId >= 0);
            //categoryRepositoryMock.Verify(ur => ur.Create(It.IsAny<Category>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
