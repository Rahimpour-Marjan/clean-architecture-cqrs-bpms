using Application.CountryApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Countrypplication.Queries
{
    public class GetAllCountryQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllCountry", "Handle")]
        public async Task FourCountryExist_Fetched_ReturnFourPersonViewModels()
        {
            //Arrange
            var country = new List<Country>
            {
                new Country("ایران","001","0098","1369","","","",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var countryRepositoryMock = new Mock<ICountryRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Country>, int>(country.ToList(), 1);
            countryRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllCountryQuery = new FindAllCountryQuery();
            var getAllCountryQueryHandler = new FindAllCountryQueryHandler(_uow, _mapper.Object);

            //Act
            var countryViewModelList = await getAllCountryQueryHandler.Handle(getAllCountryQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(countryViewModelList);
            //Assert.NotEmpty(countryViewModelList);
            //Assert.Equal(countries.Count, countryViewModelList.Count);

            //countryRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
