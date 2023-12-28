using Application.EducationLevelApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.EducationLevelpplication.Queries
{
    public class GetAllEducationLevelQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllEducationLevel", "Handle")]
        public async Task FourEducationLevelExist_Fetched_ReturnFourEducationLevelViewModels()
        {
            //Arrange
            var educationLevel = new List<EducationLevel>
            {
                new EducationLevel("دیپلم",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var educationLevelRepositoryMock = new Mock<IEducationLevelRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<EducationLevel>, int>(educationLevel.ToList(), 1);
            educationLevelRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllEducationLevelQuery = new FindAllEducationLevelQuery();
            var getAllEducationLevelQueryHandler = new FindAllEducationLevelQueryHandler(_uow, _mapper.Object);

            //Act
            var educationLevelViewModelList = await getAllEducationLevelQueryHandler.Handle(getAllEducationLevelQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(educationLevelViewModelList);
            //Assert.NotEmpty(educationLevelViewModelList);
            //Assert.Equal(educationLevels.Count, educationLevelViewModelList.Count);

            //educationLevelRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
