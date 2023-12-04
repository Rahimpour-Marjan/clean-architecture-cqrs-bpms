using Moq;
using Application.Person.Commands;
using UnitTest.Common;
using Domain;

namespace Test.Application.PersonApplication.Commands
{
    public class CreatePersonCommandHandlerTests: TestBase
    {
        [Fact]
        [Trait("PersonUser", "Handle")]
        public async void InputPerson_Created_ReturnId()
        {
            //Arrage
            var personRepositoryMock = new Mock<IPersonRepository>();

            var posts=new List<int>();
            posts.Add(1076);

            var createUserCommand = new PersonCreate.Command
            {
                FirstName = "Marjaneh",
                LastName = "Rahimpour",
                NationalCode = "0014867152",
                Phone = "09302161127",
                Email = "marjaneh.rahimpour@yahoo.com",
                FatherName = "Sia",
                PersonalNumber = "001",
                Gender = Domain.Enums.Gender.Female,
                BirthDate = DateTime.Now,
                IdentityNumber = "025",
                IsActive = true,
                EmployeementDate = DateTime.Now,
                WorkingHoursRate = 10,
                ImageUrl = "",
                DigitalSignatureUrl = "",
                OrganizationalPost="Admin",
                PostIds = posts,
            };

            var createPersonCommandHandler = new PersonCreate.Handler(_uow);

            //Act
            var result = await createPersonCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.PersonId >= 0);
            //personRepositoryMock.Verify(ur => ur.Create(It.IsAny<Person>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
