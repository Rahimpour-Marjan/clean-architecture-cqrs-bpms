using Application.ProductCategoryApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductCategoryApplication.Commands
{
    public class CreateProductCategoryCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("ProductCategory", "Handle")]
        public async void InputProductCategory_Created_ReturnId()
        {
            //Arrage
            var productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();

            var createProductCategoryCommand = new ProductCategoryCreate.Command
            {
                Title = "تهران",
                ProductCategoryParentId = 1000,
                IsActive = true,
                Url = "تست",
                Body = "تست",
                Deleted=false,
                Canonical=null,
                NoFollow = null,
                NoIndex = null,
                Priority =1,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createProductCategoryCommandHandler = new ProductCategoryCreate.Handler(_uow);

            //Act
            var result = await createProductCategoryCommandHandler.Handle(createProductCategoryCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ProductCategoryId >= 0);
            //productCategoryRepositoryMock.Verify(ur => ur.Create(It.IsAny<ProductCategory>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
