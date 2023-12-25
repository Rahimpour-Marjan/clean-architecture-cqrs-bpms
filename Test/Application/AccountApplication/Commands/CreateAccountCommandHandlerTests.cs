using Application.Account.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.AccountApplication.Commands
{
    public class CreateAccountCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("AccountUser", "Handle")]
        public async void InputAccount_Created_ReturnId()
        {
            //Arrage
            var accountRepositoryMock = new Mock<IAccountRepository>();

            var posts = new List<int>();
            posts.Add(1076);

            var createAccountCommand = new AccountCreate.Command
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
                Address = "",
                LocationLong = null,
                LocationLat = null,
                Job = "",
                Company = "",
                CompanyNo = "",
                FatherName = "",
                AccountalNumber = "",
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
                EducationSubFieldId = null,
                EducationLevelId = null,
                EmployeementDate = null,
                PostIds = posts,
            };

            var createAccountCommandHandler = new AccountCreate.Handler(_uow);

            //Act
            var result = await createAccountCommandHandler.Handle(createAccountCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.AccountId >= 0);
            //accountRepositoryMock.Verify(ur => ur.Create(It.IsAny<Account>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
