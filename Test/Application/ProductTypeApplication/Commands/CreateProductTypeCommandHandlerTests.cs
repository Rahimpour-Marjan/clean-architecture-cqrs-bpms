using Application.ProductTypeApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductTypeApplication.Commands
{
    public class CreateProductTypeCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("ProductType", "Handle")]
        public async void InputProductType_Created_ReturnId()
        {
            //Arrage
            var productTypeRepositoryMock = new Mock<IProductTypeRepository>();

            var createProductTypeCommand = new ProductTypeCreate.Command
            {
                Title = "تهران",
                ProductTypeParentId = 1000,
                IsActive = true,
                H1="تست",
                Url = "تست",
                Body = "تست",
                Priority=1,
                ImageUrl = "",
                CreatorId = 1000,
            };

            var createProductTypeCommandHandler = new ProductTypeCreate.Handler(_uow);

            //Act
            var result = await createProductTypeCommandHandler.Handle(createProductTypeCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ProductTypeId >= 0);
            //productTypeRepositoryMock.Verify(ur => ur.Create(It.IsAny<ProductType>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
