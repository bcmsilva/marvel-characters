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
    public class EventsQueryHandlerTest
    {
        private Mock<IEventsRepository> _mockRepository;
        private EventsQueryHandler _handler;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IEventsRepository>();
            _handler = new EventsQueryHandler(_mockRepository.Object);
        }

        [TestMethod]
        public void ShouldReturnEventsWhenRequestIsValid()
        {
            var request = new GetEventsByIdCharacterQuery
            {
                IdCharacter = 123,
                Limit = 20,
                OffSet = 0
            };

            var repositoryResult = new PagedQueryResult<EventQueryResult>();

            _mockRepository
                .Setup(s => s.GetEventsByIdCharacterAsync(request))
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
        public void ShouldReturnErrorWhenGetCharactersRequestInvalid(int idCharacter, int limit, int offSet)
        {
            var request = new GetEventsByIdCharacterQuery
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
