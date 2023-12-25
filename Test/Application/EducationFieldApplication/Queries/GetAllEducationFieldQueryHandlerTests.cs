using Application.EducationFieldApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.EducationFieldpplication.Queries
{
    public class GetAllEducationFieldQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllEducationField", "Handle")]
        public async Task FourEducationFieldExist_Fetched_ReturnFourEducationFieldViewModels()
        {
            //Arrange
            var educationField = new List<EducationField>
            {
                new EducationField("دیپلم",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var educationFieldRepositoryMock = new Mock<IEducationFieldRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<EducationField>, int>(educationField.ToList(), 1);
            educationFieldRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllEducationFieldQuery = new FindAllEducationFieldQuery();
            var getAllEducationFieldQueryHandler = new FindAllEducationFiledQueryHandler(_uow, _mapper.Object);

            //Act
            var educationFieldViewModelList = await getAllEducationFieldQueryHandler.Handle(getAllEducationFieldQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(educationFieldViewModelList);
            //Assert.NotEmpty(countryViewModelList);
            //Assert.Equal(educationFields.Count, educationFieldViewModelList.Count);

            //educationFieldRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
