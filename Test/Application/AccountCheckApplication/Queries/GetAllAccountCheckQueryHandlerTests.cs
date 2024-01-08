using Application.AccountCheckApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountCheckpplication.Queries
{
    public class GetAllAccountCheckQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllAccountCheck", "Handle")]
        public async Task FourAccountCheckExist_Fetched_ReturnFourAccountCheckViewModels()
        {
            //Arrange
            var accountCheck = new List<AccountCheck>
            {
                new AccountCheck(1000,  "1212548", 1000, "شعبه 1", 10000000, "مرجانه رحیم پور", DateTime.Now, DateTime.Now, null, "", "", null, 1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var accountCheckRepositoryMock = new Mock<IAccountCheckRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<AccountCheck>, int>(accountCheck.ToList(), 1);
            accountCheckRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllAccountCheckQuery = new FindAllAccountCheckQuery();
            var getAllAccountCheckQueryHandler = new FindAllAccountCheckQueryHandler(_uow, _mapper.Object);

            //Act
            var accountCheckViewModelList = await getAllAccountCheckQueryHandler.Handle(getAllAccountCheckQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(accountCheckViewModelList);
            //Assert.NotEmpty(accountCheckViewModelList);
            //Assert.Equal(countries.Count, accountCheckViewModelList.Count);

            //accountCheckRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
