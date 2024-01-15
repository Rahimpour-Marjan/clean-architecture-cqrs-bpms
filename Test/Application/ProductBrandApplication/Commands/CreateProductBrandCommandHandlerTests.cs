using Application.ProductBrandApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductBrandApplication.Commands
{
    public class CreateProductBrandCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("ProductBrand", "Handle")]
        public async void InputProductBrand_Created_ReturnId()
        {
            //Arrage
            var productBrandRepositoryMock = new Mock<IProductBrandRepository>();

            var createProductBrandCommand = new ProductBrandCreate.Command
            {
                Title = "تهران",
                ProductTypeId = 1000,
                IsActive = true,
                H1="تست",
                Url = "تست",
                Body = "تست",
                Description=null,
                Priority=1,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createProductBrandCommandHandler = new ProductBrandCreate.Handler(_uow);

            //Act
            var result = await createProductBrandCommandHandler.Handle(createProductBrandCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ProductBrandId >= 0);
            //productBrandRepositoryMock.Verify(ur => ur.Create(It.IsAny<ProductBrand>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
