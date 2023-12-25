using Application.EducationSubFieldApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.EducationSubFieldpplication.Queries
{
    public class GetAllEducationSubFieldQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllEducationSubField", "Handle")]
        public async Task FourEducationSubFieldExist_Fetched_ReturnFourEducationSubFieldViewModels()
        {
            //Arrange
            var educationSubField = new List<EducationSubField>
            {
                new EducationSubField("دیپلم",1000,DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var educationSubFieldRepositoryMock = new Mock<IEducationSubFieldRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<EducationSubField>, int>(educationSubField.ToList(), 1);
            educationSubFieldRepositoryMock.Setup(pr => pr.FindAll(queryFilter, 1000).Result).Returns(result);

            var getAllEducationSubFieldQuery = new FindAllEducationSubFieldQuery();
            var getAllEducationSubFieldQueryHandler = new FindAllEducationSubFieldQueryHandler(_uow, _mapper.Object);

            //Act
            var educationSubFieldViewModelList = await getAllEducationSubFieldQueryHandler.Handle(getAllEducationSubFieldQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(educationSubFieldViewModelList);
            //Assert.NotEmpty(educationSubFieldViewModelList);
            //Assert.Equal(educationSubFields.Count, educationSubFieldViewModelList.Count);

            //educationSubFieldRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
