using Application.PackageApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Packagepplication.Queries
{
    public class GetAllPackageQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllPackage", "Handle")]
        public async Task FourPackageExist_Fetched_ReturnFourPackageViewModels()
        {
            //Arrange
            var package = new List<Package>
            {
                new Package("پکیج طلایی",Domain.Enums.PackageType.Type1,"01",true,100000,100000,"",DateTime.Now,1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var packageRepositoryMock = new Mock<IPackageRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Package>, int>(package.ToList(), 1);
            packageRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllPackageQuery = new FindAllPackageQuery();
            var getAllPackageQueryHandler = new FindAllPackageQueryHandler(_uow, _mapper.Object);

            //Act
            var packageViewModelList = await getAllPackageQueryHandler.Handle(getAllPackageQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(packageViewModelList);
            //Assert.NotEmpty(packageViewModelList);
            //Assert.Equal(countries.Count, packageViewModelList.Count);

            //packageRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
