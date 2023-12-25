using Application.AccountAddressApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountAddresspplication.Queries
{
    public class GetAllAccountAddressQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllAccountAddress", "Handle")]
        public async Task FourAccountAddressExist_Fetched_ReturnFourAccountAddressViewModels()
        {
            //Arrange
            var accountAddress = new List<AccountAddress>
            {
                new AccountAddress(1000,"آدرس من","مرجانه رحیم پور","09302161127",null,1000,1000,1000,1000,"آدرس 400 کاراکتری","0098","1369587954","","",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var accountAddressRepositoryMock = new Mock<IAccountAddressRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<AccountAddress>, int>(accountAddress.ToList(), 1);
            accountAddressRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllAccountAddressQuery = new FindAllAccountAddressQuery();
            var getAllAccountAddressQueryHandler = new FindAllAccountAddressQueryHandler(_uow, _mapper.Object);

            //Act
            var AccountAddressViewModelList = await getAllAccountAddressQueryHandler.Handle(getAllAccountAddressQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(AccountAddressViewModelList);
            //Assert.NotEmpty(accountAddressViewModelList);
            //Assert.Equal(accountAddresss.Count, accountAddressViewModelList.Count);

            //accountAddressRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
