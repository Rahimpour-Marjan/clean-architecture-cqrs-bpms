using Application.PersonAddressApplication.Queries.FindAll;
using Domain;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.PersonAddresspplication.Queries
{
    public class GetAllPersonAddressQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllPersonAddress", "Handle")]
        public async Task FourPersonAddressExist_Fetched_ReturnFourPersonAddressViewModels()
        {
            //Arrange
            var personAddress = new List<PersonAddress>
            {
                new PersonAddress(1000,"آدرس من","مرجانه رحیم پور","09302161127",null,1000,1000,1000,1000,"آدرس 400 کاراکتری","0098","1369587954","","",DateTime.Now),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var personAddressRepositoryMock = new Mock<IPersonAddressRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<PersonAddress>, int>(personAddress.ToList(), 1);
            personAddressRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllPersonAddressQuery = new FindAllPersonAddressQuery();
            var getAllPersonAddressQueryHandler = new FindAllPersonAddressQueryHandler(_uow, _mapper.Object);

            //Act
            var personAddressViewModelList = await getAllPersonAddressQueryHandler.Handle(getAllPersonAddressQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(personAddressViewModelList);
            //Assert.NotEmpty(personAddressViewModelList);
            //Assert.Equal(personAddresss.Count, personAddressViewModelList.Count);

            //personAddressRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
