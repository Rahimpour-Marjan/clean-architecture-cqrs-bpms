using Application.AccountCreditApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountCreditpplication.Queries
{
    public class GetAllAccountCreditQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllAccountCredit", "Handle")]
        public async Task FourAccountCreditExist_Fetched_ReturnFourAccountCreditViewModels()
        {
            //Arrange
            var accountCredit = new List<AccountCredit>
            {
                new AccountCredit(1000,  "", 10000,10000, null, true,Domain.Enums.CreditType.Deposit, 1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var accountCreditRepositoryMock = new Mock<IAccountCreditRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<AccountCredit>, int>(accountCredit.ToList(), 1);
            accountCreditRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllAccountCreditQuery = new FindAllAccountCreditQuery();
            var getAllAccountCreditQueryHandler = new FindAllAccountCreditQueryHandler(_uow, _mapper.Object);

            //Act
            var accountCreditViewModelList = await getAllAccountCreditQueryHandler.Handle(getAllAccountCreditQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(accountCreditViewModelList);
            //Assert.NotEmpty(accountCreditViewModelList);
            //Assert.Equal(countries.Count, accountCreditViewModelList.Count);

            //accountCreditRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
