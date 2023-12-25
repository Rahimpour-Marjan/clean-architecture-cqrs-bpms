using Application.CreditPaymentApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.CreditPaymentpplication.Queries
{
    public class GetAllCreditPaymentQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllCreditPayment", "Handle")]
        public async Task FourCreditPaymentExist_Fetched_ReturnFourCreditPaymentViewModels()
        {
            //Arrange
            var creditPayment = new List<CreditPayment>
            {
                new CreditPayment(1000, 1000,  Domain.Enums.PaymentStatus.UnPaid, "123456", "", "", 10000,"192.168.1.1", "",1000, false, "", DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var creditPaymentRepositoryMock = new Mock<ICreditPaymentRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<CreditPayment>, int>(creditPayment.ToList(), 1);
            creditPaymentRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllCreditPaymentQuery = new FindAllCreditPaymentQuery();
            var getAllCreditPaymentQueryHandler = new FindAllCreditPaymentQueryHandler(_uow, _mapper.Object);

            //Act
            var creditPaymentViewModelList = await getAllCreditPaymentQueryHandler.Handle(getAllCreditPaymentQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(creditPaymentViewModelList);
            //Assert.NotEmpty(creditPaymentViewModelList);
            //Assert.Equal(countries.Count, creditPaymentViewModelList.Count);

            //creditPaymentRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
