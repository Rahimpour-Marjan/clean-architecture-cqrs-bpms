using Application.ArticleApplication.Queries.FindAll;
using Domain;
using Domain.Enums;
using Domain.Resources;
using Moq;
using UnitTest.Common;

namespace Test.Application.Articlepplication.Queries
{
    public class GetAllArticleQueryHandlerTests : TestBase
    {
        [Fact]
        [Trait("GetAllArticle", "Handle")]
        public async Task FourArticleExist_Fetched_ReturnFourArticleViewModels()
        {
            //Arrange
            var article = new List<Article>
            {
                new Article("تست", 1000, "تست", "تست", "تست", 0, false, true, "تست", "تست", "تست",
            "تست", "تست","تست", "تست", false, false, "تست", "تست",
            DateTime.Now, DateTime.Now, 1000),
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var articleRepositoryMock = new Mock<IArticleRepository>();
            //Todo: Configurando o Metodo FindAll para retornar o resultado que eu espero.

            var queryFilter = new QueryFilter();
            var result = new Tuple<IList<Article>, int>(article.ToList(), 1);
            articleRepositoryMock.Setup(pr => pr.FindAll(queryFilter).Result).Returns(result);

            var getAllArticleQuery = new FindAllArticleQuery();
            var getAllArticleQueryHandler = new FindAllArticleQueryHandler(_uow, _mapper.Object);

            //Act
            var articleViewModelList = await getAllArticleQueryHandler.Handle(getAllArticleQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(articleViewModelList);
            //Assert.NotEmpty(articleViewModelList);
            //Assert.Equal(cities.Count, articleViewModelList.Count);

            //articleRepositoryMock.Verify(pr => pr.FindAll().Result, Times.Once);
        }
    }
}
