using Application.CategoryApplication.Queries.FindAll;
using Domain;
using Domain.Enums;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Categorypplication.Queries
{
    public class GetAllCategoryQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllCategory", "Handle")]
        public async Task FourCategoryExist_Fetched_ReturnFourCategoryViewModels()
        {
            //Arrange
            var category = new List<Category>
            {
                new Category("تست",CategoryType.Gallery,true,"تست","تست","",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Category>, int>(category.ToList(), 1);
            categoryRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllCategoryQuery = new FindAllCategoryQuery();
            var getAllCategoryQueryHandler = new FindAllCategoryQueryHandler(_uow, _mapper.Object);

            //Act
            var categoryViewModelList = await getAllCategoryQueryHandler.Handle(getAllCategoryQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(categoryViewModelList);
            //Assert.NotEmpty(categoryViewModelList);
            //Assert.Equal(cities.Count, categoryViewModelList.Count);

            //categoryRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
