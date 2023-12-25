using Application.CurrencyTypeApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.CurrencyTypepplication.Queries
{
    public class GetAllCurrencyTypeQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllCurrencyType", "Handle")]
        public async Task FourCurrencyTypeExist_Fetched_ReturnFourCurrencyTypeViewModels()
        {
            //Arrange
            var currencyType = new List<CurrencyType>
            {
                new CurrencyType("ریال","ریال",1000,"",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var currencyTypeRepositoryMock = new Mock<ICurrencyTypeRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<CurrencyType>, int>(currencyType.ToList(), 1);
            currencyTypeRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllCurrencyTypeQuery = new FindAllCurrencyTypeQuery();
            var getAllCurrencyTypeQueryHandler = new FindAllCurrencyTypeQueryHandler(_uow, _mapper.Object);

            //Act
            var currencyTypeViewModelList = await getAllCurrencyTypeQueryHandler.Handle(getAllCurrencyTypeQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(currencyTypeViewModelList);
            //Assert.NotEmpty(currencyTypeViewModelList);
            //Assert.Equal(countries.Count, currencyTypeViewModelList.Count);

            //currencyTypeRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
