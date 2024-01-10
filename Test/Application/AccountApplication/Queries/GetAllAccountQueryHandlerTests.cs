using Application.Account.Queries.FindAll;
using Domain;
using Domain.Enums;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Accountpplication.Queries
{
    public class GetAllAccountQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllAccount", "Handle")]
        public async Task FourAccountExist_Fetched_ReturnFourAccountViewModels()
        {
            //Arrange
            var account = new List<Account>
            {
                new Account("مرجانه", "رحیم پور", UserType.DynamicUser, Gender.Female, DateTime.Now, "0014867151", "09302161127", "", "", "",
                                        "rahimpour.marjaneh@gmail.com", "", "", "", "", "", "", "", "",
                                        null, null, null, null, "", "", "", "", "makmon", "001",
                                        "سیاوش", "1", true, null, "خودم", "خودم", "آدرس تصویر", "امضا", "آدرس رزومه", true,
                                        false, null, null, null, DateTime.Now, 1000)
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var accountRepositoryMock = new Mock<IAccountRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Account>, int>(account.ToList(), 1);
            //AccountRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllAccountQuery = new FindAllAccountQuery();
            var getAllAccountQueryHandler = new FindAllAccountQueryHandler(_uow, _mapper.Object);

            //Act
            var accountViewModelList = await getAllAccountQueryHandler.Handle(getAllAccountQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(accountViewModelList);
            //Assert.NotEmpty(AccountViewModelList);
            //Assert.Equal(users.Count, userViewModelList.Count);

            //userRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
