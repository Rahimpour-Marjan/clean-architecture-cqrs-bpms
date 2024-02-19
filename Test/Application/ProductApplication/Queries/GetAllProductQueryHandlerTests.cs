using Application.ProductApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Productpplication.Queries
{
    public class GetAllProductQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllProduct", "Handle")]
        public async Task FourProductExist_Fetched_ReturnFourProductViewModels()
        {
            //Arrange
            var product = new List<Product>
            {
                new Product("تست",1000, 1000, 1000, "تست", "تست","001","تست", "تست",
                    "تست", 1,null, null, null, null, null, null, null, null, false, null,
                    null, null, null, null, null, null, null, null,
                    false, false, null, false, false, false, false,  false, false,true,
                    null, null, null, 1000)
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var productRepositoryMock = new Mock<IProductRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Product>, int>(product.ToList(), 1);
            productRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllProductQuery = new FindAllProductQuery();
            var getAllProductQueryHandler = new FindAllProductQueryHandler(_uow, _mapper.Object);

            //Act
            var productViewModelList = await getAllProductQueryHandler.Handle(getAllProductQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(productViewModelList);
            //Assert.NotEmpty(productViewModelList);
            //Assert.Equal(cities.Count, productViewModelList.Count);

            //productRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
