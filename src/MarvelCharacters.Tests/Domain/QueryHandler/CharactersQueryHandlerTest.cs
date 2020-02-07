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
    public class CharactersQueryHandlerTest
    {
        private Mock<ICharactersRepository> _mockRepository;
        private CharactersQueryHandler _handler;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<ICharactersRepository>();
            _handler = new CharactersQueryHandler(_mockRepository.Object);
        }

        [TestMethod]
        public void ShouldReturnCharactersWhenRequestIsValid()
        {
            var request = new GetCharactersQuery
            {
                Limit = 20,
                OffSet = 0
            };

            var repositoryResult = new PagedQueryResult<CharacterQueryResult>();

            _mockRepository
                .Setup(s => s.GetCharactersAsync(request))
                .Returns(Task.FromResult(repositoryResult));

            var result = _handler.Handle(request);

            Assert.IsTrue(request.Valid);
            Assert.IsTrue(_handler.Valid);
            Assert.IsTrue(result.Result.Success);
            Assert.AreEqual(result.Result.Data, repositoryResult);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(-1, 0)]
        [DataRow(101, 0)]
        [DataRow(20, -1)]
        public void ShouldReturnErrorWhenGetCharactersRequestInvalid(int limit, int offSet)
        {
            var request = new GetCharactersQuery
            {
                Limit = limit,
                OffSet = offSet
            };

            var result = _handler.Handle(request);

            Assert.IsFalse(request.Valid);
            Assert.IsFalse(_handler.Valid);
            Assert.IsFalse(result.Result.Success);
        }

        [TestMethod]
        public void ShouldReturnOneCharacterWhenRequestIsValid()
        {
            var request = new GetOneCharacterQuery
            {
                IdCharacter = 123
            };

            var repositoryResult = new PagedQueryResult<CharacterQueryResult>();

            _mockRepository
                .Setup(s => s.GetOneCharacterAsync(request))
                .Returns(Task.FromResult(repositoryResult));

            var result = _handler.Handle(request);

            Assert.IsTrue(request.Valid);
            Assert.IsTrue(_handler.Valid);
            Assert.IsTrue(result.Result.Success);
            Assert.AreEqual(result.Result.Data, repositoryResult);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenGetOneCharacterRequestInvalid()
        {
            var request = new GetOneCharacterQuery
            {
                IdCharacter = 0
            };

            var result = _handler.Handle(request);

            Assert.IsFalse(request.Valid);
            Assert.IsFalse(_handler.Valid);
            Assert.IsFalse(result.Result.Success);
        }
    }
}
