using Application.PackageApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.PackageApplication.Commands
{
    public class CreatePackageCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Package", "Handle")]
        public async void InputPackage_Created_ReturnId()
        {
            //Arrage
            var packageRepositoryMock = new Mock<IPackageRepository>();

            var createPackageCommand = new PackageCreate.Command
            {
                Title = "پکیج طلایی",
                Type = Domain.Enums.PackageType.Type1,
                Code = "01",
                IsActive = true,
                Price = 100000,
                Discount = 100000,
                ImageUrl = "",
                ExpireDate = DateTime.Now,
                CreatorId = 1000,
            };

            var createPackageCommandHandler = new PackageCreate.Handler(_uow);

            //Act
            var result = await createPackageCommandHandler.Handle(createPackageCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.PackageId >= 0);
            //packageRepositoryMock.Verify(ur => ur.Create(It.IsAny<Package>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
