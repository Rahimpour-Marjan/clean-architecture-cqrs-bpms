using Application.ProductBrandApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductBrandpplication.Queries
{
    public class GetAllProductBrandQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllProductBrand", "Handle")]
        public async Task FourProductBrandExist_Fetched_ReturnFourProductBrandViewModels()
        {
            //Arrange
            var productBrand = new List<ProductBrand>
            {
                new ProductBrand("تست",1000,true,"تست","تست","تست",null,1,"تست",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var productBrandRepositoryMock = new Mock<IProductBrandRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<ProductBrand>, int>(productBrand.ToList(), 1);
            productBrandRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllProductBrandQuery = new FindAllProductBrandQuery();
            var getAllProductBrandQueryHandler = new FindAllProductBrandQueryHandler(_uow, _mapper.Object);

            //Act
            var productBrandViewModelList = await getAllProductBrandQueryHandler.Handle(getAllProductBrandQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(productBrandViewModelList);
            //Assert.NotEmpty(productBrandViewModelList);
            //Assert.Equal(cities.Count, productBrandViewModelList.Count);

            //productBrandRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
