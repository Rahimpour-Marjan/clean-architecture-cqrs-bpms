using Application.ArticleApplication.Commands;
using Domain;
using Moq;
using UnitTest.Common;

namespace Test.Application.ArticleApplication.Commands
{
    public class CreateArticleCommandHandlerTests : TestBase
    {
        [Fact]
        [Trait("Article", "Handle")]
        public async void InputArticle_Created_ReturnId()
        {
            //Arrage
            var articleRepositoryMock = new Mock<IArticleRepository>();

            var createArticleCommand = new ArticleCreate.Command
            {
                Title = "تست",
                CategoryId = 1000,
                Keywords = "تست",
                Summary = "تست",
                Body = "تست",
                VisitCount = 0,
                IsSlider = false,
                Active = true,
                Url = "تست",
                H1 = "تست",
                Writer = "تست",
                WriterPosition = "تست",
                WriterImageUrl = "تست",
                Aparat = "تست",
                Canonical = "تست",
                NoFollow = false,
                NoIndex = false,
                PostLabel = "تست",
                ImageUrl = "تست",
                ShowDateTime = DateTime.Now,
                ExpireDateTime = DateTime.Now,
                CreatorId = 1000,
            };

            var createArticleCommandHandler = new ArticleCreate.Handler(_uow);

            //Act
            var result = await createArticleCommandHandler.Handle(createArticleCommand, new CancellationToken());

            //Assert
            Assert.True(result.Result.ArticleId >= 0);
            //articleRepositoryMock.Verify(ur => ur.Create(It.IsAny<Article>()), Times.Once);
            //authserviceMock.Verify(ur => ur.GenerateHashPasswordAndSalt(It.IsAny<string>()), Times.Once);
        }
    }
}
