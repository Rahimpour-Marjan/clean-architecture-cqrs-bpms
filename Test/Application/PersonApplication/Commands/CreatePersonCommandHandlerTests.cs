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
                Gender = Domain.Enums.Gender.Female,
                BirthDate = DateTime.Now,
                NationalCode = "0014867151",
                Phone = "09302161127",
                ExtraPhone1 = "",
                ExtraPhone2 = "",
                ExtraPhone3 = "",
                Email = "rahimpour.marjaneh@gmail.com",
                ExtraEmail = "",
                Fax = "",
                Website = "",
                Instagram = "",
                Telegram = "",
                WhatsApp = "",
                Linkedin = "",
                Facebook = "",
                CountryId = null,
                StateId = null,
                CityId = null,
                ZoneId = null,
                Address ="",
                LocationLong = null,
                LocationLat = null,
                Job = "",
                Company = "",
                CompanyNo = "",
                FatherName = "",
                PersonalNumber = "",
                IsActive = true,
                WorkingHoursRate = null,
                ReagentName = "",
                ReagentCode = "",
                ImageUrl = "",
                DigitalSignatureUrl = "",
                ResumeUrl = "",
                SpacialAccount = false,
                IsPublic = false,
                PackageId = null,
                EducationFieldId = null,
                EducationLevelId = null,
                EmployeementDate = null,
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
