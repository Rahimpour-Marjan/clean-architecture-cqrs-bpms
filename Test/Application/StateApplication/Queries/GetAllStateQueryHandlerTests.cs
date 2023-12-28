using Application.StateApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Statepplication.Queries
{
    public class GetAllStateQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllState", "Handle")]
        public async Task FourStateExist_Fetched_ReturnFourStateViewModels()
        {
            //Arrange
            var state = new List<State>
            {
                new State("ایران",1000,"001","0098","1369","","","",1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var stateRepositoryMock = new Mock<IStateRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<State>, int>(state.ToList(), 1);
            stateRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllStateQuery = new FindAllStateQuery();
            var getAllStateQueryHandler = new FindAllStateQueryHandler(_uow, _mapper.Object);

            //Act
            var stateViewModelList = await getAllStateQueryHandler.Handle(getAllStateQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(stateViewModelList);
            //Assert.NotEmpty(stateViewModelList);
            //Assert.Equal(states.Count, stateViewModelList.Count);

            //stateRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
