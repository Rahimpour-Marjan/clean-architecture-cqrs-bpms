using Application.CityApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Citypplication.Queries
{
    public class GetAllCityQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllCity", "Handle")]
        public async Task FourCityExist_Fetched_ReturnFourCityViewModels()
        {
            //Arrange
            var city = new List<City>
            {
                new City("ایران",1000,"001","0098","1369","","","",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var cityRepositoryMock = new Mock<ICityRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<City>, int>(city.ToList(), 1);
            cityRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllCityQuery = new FindAllCityQuery();
            var getAllCityQueryHandler = new FindAllCityQueryHandler(_uow, _mapper.Object);

            //Act
            var cityViewModelList = await getAllCityQueryHandler.Handle(getAllCityQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(cityViewModelList);
            //Assert.NotEmpty(cityViewModelList);
            //Assert.Equal(cities.Count, cityViewModelList.Count);

            //cityRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
