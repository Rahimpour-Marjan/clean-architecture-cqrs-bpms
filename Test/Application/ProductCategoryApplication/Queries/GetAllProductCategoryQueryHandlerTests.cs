using Application.ProductCategoryApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.ProductCategorypplication.Queries
{
    public class GetAllProductCategoryQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllProductCategory", "Handle")]
        public async Task FourProductCategoryExist_Fetched_ReturnFourProductCategoryViewModels()
        {
            //Arrange
            var productCategory = new List<ProductCategory>
            {
                new ProductCategory("تست",1000,true,"تست","تست",null,null,null,null,1,"تست",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<ProductCategory>, int>(productCategory.ToList(), 1);
            productCategoryRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllProductCategoryQuery = new FindAllProductCategoryQuery();
            var getAllProductCategoryQueryHandler = new FindAllProductCategoryQueryHandler(_uow, _mapper.Object);

            //Act
            var productCategoryViewModelList = await getAllProductCategoryQueryHandler.Handle(getAllProductCategoryQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(productCategoryViewModelList);
            //Assert.NotEmpty(productCategoryViewModelList);
            //Assert.Equal(cities.Count, productCategoryViewModelList.Count);

            //productCategoryRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
