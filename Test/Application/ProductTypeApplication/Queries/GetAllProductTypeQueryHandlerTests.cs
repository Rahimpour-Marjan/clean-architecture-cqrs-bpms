using Application.ProductTypeApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductTypepplication.Queries
{
    public class GetAllProductTypeQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllProductType", "Handle")]
        public async Task FourProductTypeExist_Fetched_ReturnFourProductTypeViewModels()
        {
            //Arrange
            var productType = new List<ProductType>
            {
                new ProductType("تست",1000,true,"تست","تست",null,1,"تست",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var productTypeRepositoryMock = new Mock<IProductTypeRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<ProductType>, int>(productType.ToList(), 1);
            productTypeRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllProductTypeQuery = new FindAllProductTypeQuery();
            var getAllProductTypeQueryHandler = new FindAllProductTypeQueryHandler(_uow, _mapper.Object);

            //Act
            var productTypeViewModelList = await getAllProductTypeQueryHandler.Handle(getAllProductTypeQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(productTypeViewModelList);
            //Assert.NotEmpty(productTypeViewModelList);
            //Assert.Equal(cities.Count, productTypeViewModelList.Count);

            //productTypeRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
