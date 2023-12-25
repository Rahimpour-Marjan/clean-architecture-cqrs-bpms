using Application.BankApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Bankpplication.Queries
{
    public class GetAllBankQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllBank", "Handle")]
        public async Task FourBankExist_Fetched_ReturnFourBankViewModels()
        {
            //Arrange
            var bank = new List<Bank>
            {
                new Bank("ایران",true,"",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var bankRepositoryMock = new Mock<IBankRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Bank>, int>(bank.ToList(), 1);
            bankRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllBankQuery = new FindAllBankQuery();
            var getAllBankQueryHandler = new FindAllBankQueryHandler(_uow, _mapper.Object);

            //Act
            var bankViewModelList = await getAllBankQueryHandler.Handle(getAllBankQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(bankViewModelList);
            //Assert.NotEmpty(bankViewModelList);
            //Assert.Equal(countries.Count, bankViewModelList.Count);

            //bankRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
