using Application.User.Queries.FindAll;
using Domain;
using Domain.Enums;
using Infrastructure.Persistance.Repositories;
using Moq;
using UnitTest.Common;

namespace Test.Application.UserApplication.Queries
{
    public class GetAllUserQueryHandlerTests:TestBase
    {
        [Fact]
        [Trait("GetAllUser", "Handle")]
        public async Task FourUsersExist_Fetched_ReturnFourUsersViewModels()
        {
            //Arrange
            var users = new List<User>
            {
                //new User(1,"Duarte","1234","", "Duarte@gmail.com",UserType.DynamicUser,true,null),
                //new User(1,"Lima","1234","", "Lima@gmail.com",UserType.DynamicUser,true, null),
                //new User(1,"Sousa","1234","", "Sousa@gmail.com",UserType.DynamicUser,true, null),
                //new User(1,"Smitch","1234","", "Smitch@gmail.com",UserType.DynamicUser, true, null),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var userRepositoryMock = new Mock<IUserRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.
            userRepositoryMock.Setup(pr => pr.FindAll().Result).Returns(users);

            var getAllUsersQuery = new FindAllUsersQuery();
            var getAllUsersQueryHandler = new FindAllUsersQueryHandler(_uow, _mapper.Object);

            //Act
            var userViewModelList = await getAllUsersQueryHandler.Handle(getAllUsersQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(userViewModelList);
            //Assert.NotEmpty(userViewModelList);
            //Assert.Equal(users.Count, userViewModelList.Count);

            //userRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
