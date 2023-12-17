using Application.Person.Queries.FindAll;
using Domain;
using Domain.Enums;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Personpplication.Queries
{
    public class GetAllPersonQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllPerson", "Handle")]
        public async Task FourPersonExist_Fetched_ReturnFourPersonViewModels()
        {
            //Arrange
            var person = new List<Person>
            {
                new Person("مرجانه", "رحیم پور", UserType.DynamicUser, Gender.Female, DateTime.Now, "0014867151", "09302161127", "", "", "",
                                        "rahimpour.marjaneh@gmail.com", "", "", "", "", "", "", "", "",
                                        null, null, null, null, "", "", "", "", "makmon", "001",
                                        "سیاوش", "1", true, null, "خودم", "خودم", "آدرس تصویر", "امضا", "آدرس رزومه", true,
                                        false, null, null, null, DateTime.Now, DateTime.Now)
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var personRepositoryMock = new Mock<IPersonRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Person>, int>(person.ToList(), 1);
            personRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllpersonQuery = new FindAllPersonQuery();
            var getAllpersonQueryHandler = new FindAllPersonQueryHandler(_uow, _mapper.Object);

            //Act
            var personViewModelList = await getAllpersonQueryHandler.Handle(getAllpersonQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(personViewModelList);
            //Assert.NotEmpty(personViewModelList);
            //Assert.Equal(users.Count, userViewModelList.Count);

            //userRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
