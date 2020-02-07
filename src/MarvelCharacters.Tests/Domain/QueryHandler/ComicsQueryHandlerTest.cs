using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.QueryHandler;
using MarvelCharacters.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace MarvelCharacters.Tests.Domain.QueryHandler
{
    [TestClass]
    public class ComicsQueryHandlerTest
    {
        private Mock<IComicsRepository> _mockRepository;
        private ComicsQueryHandler _handler;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IComicsRepository>();
            _handler = new ComicsQueryHandler(_mockRepository.Object);
        }

        [TestMethod]
        public void ShouldReturnComicsWhenRequestIsValid()
        {
            var request = new GetComicsByIdCharacterQuery
            {
                IdCharacter = 123,
                Limit = 20,
                OffSet = 0
            };

            var repositoryResult = new PagedQueryResult<ComicQueryResult>();

            _mockRepository
                .Setup(s => s.GetComicsByIdCharacterAsync(request))
                .Returns(Task.FromResult(repositoryResult));

            var result = _handler.Handle(request);

            Assert.IsTrue(request.Valid);
            Assert.IsTrue(_handler.Valid);
            Assert.IsTrue(result.Result.Success);
            Assert.AreEqual(result.Result.Data, repositoryResult);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(0, 20, 0)]
        [DataRow(1, -1, 0)]
        [DataRow(1, 101, 0)]
        [DataRow(1, 20, -1)]
        public void ShouldReturnErrorWhenRequestInvalid(int idCharacter, int limit, int offSet)
        {
            var request = new GetComicsByIdCharacterQuery
            {
                IdCharacter = idCharacter,
                Limit = limit,
                OffSet = offSet
            };

            var result = _handler.Handle(request);

            Assert.IsFalse(request.Valid);
            Assert.IsFalse(_handler.Valid);
            Assert.IsFalse(result.Result.Success);
        }
    }
}
