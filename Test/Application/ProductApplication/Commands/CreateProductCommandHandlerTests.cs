using Application.ProductApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductApplication.Commands
{
    public class CreateProductCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Product", "Handle")]
        public async void InputProduct_Created_ReturnId()
        {
            //Arrage
            var productRepositoryMock = new Mock<IProductRepository>();

            var createProductCommand = new ProductCreate.Command
            {
                Title = "تست",
                ProductTypeId = 1000,
                ProductCategoryId = 1000,
                ProductBrandId = 1000,
                H1 = "تست",
                Url = "تست",
                CodeValue = "001",
                Summary = "تست",
                Description = "تست",
                Body = "تست",
                Priority = 1,
                MaxShowCount = null,
                Quantity = null,
                MinOrder = null,
                LastPrice = null,
                Price = null,
                MinPrice = null,
                MaxPrice = null,
                VisitCount = null,
                ShowHomePage = false,
                Latitude = null,
                Longitude = null,
                SellCount = null,
                MaxOrderCount = null,
                DiscountValue = null,
                DiscountPercent = null,
                DiscountExpireDate = null,
                MetaTagDescription = null,
                Canonical = null,
                NoFollow = false,
                NoIndex = false,
                Keywords =null,
                IsService = false,
                IsCopy = false,
                IsPublic = false,
                IsActive = true,
                VideoDemoFileUrl = null,
                ImageUrl = null,
                CreatorStoreId = null,
                CreatorId = 1000,
            };

            var createProductCommandHandler = new ProductCreate.Handler(_uow);

            //Act
            var result = await createProductCommandHandler.Handle(createProductCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ProductId >= 0);
            //productRepositoryMock.Verify(ur => ur.Create(It.IsAny<Product>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
