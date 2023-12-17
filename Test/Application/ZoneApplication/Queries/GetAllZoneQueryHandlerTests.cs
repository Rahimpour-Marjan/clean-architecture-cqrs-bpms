using Application.ZoneApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Zonepplication.Queries
{
    public class GetAllZoneQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllZone", "Handle")]
        public async Task FourZoneExist_Fetched_ReturnFourZoneViewModels()
        {
            //Arrange
            var zone = new List<Zone>
            {
                new Zone("منطقه 1",1000,"001","0098","1369","","","",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var zoneRepositoryMock = new Mock<IZoneRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Zone>, int>(zone.ToList(), 1);
            zoneRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllZoneQuery = new FindAllZoneQuery();
            var getAllZoneQueryHandler = new FindAllZoneQueryHandler(_uow, _mapper.Object);

            //Act
            var zoneViewModelList = await getAllZoneQueryHandler.Handle(getAllZoneQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(zoneViewModelList);
            //Assert.NotEmpty(zoneViewModelList);
            //Assert.Equal(zones.Count, zoneViewModelList.Count);

            //zoneRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
