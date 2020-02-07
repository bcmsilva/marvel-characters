using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Infra.Repositories;
using MarvelCharacters.Tests.Infra.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;

namespace MarvelCharacters.Tests.Infra.Repositories
{
    [TestClass]
    public class EventsRepositoryTests
    {
        private FakeMarvelCatalogContext _dbContext;
        private EventsRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new FakeMarvelCatalogContext();
            _dbContext.InitializeData();
            _repository = new EventsRepository(_dbContext);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1009351, 20, 0, null, null, null, "Acts of Vengeance!", 1)]
        [DataRow(1009351, 20, 0, "Acts of Vengeance!", null, null, "Acts of Vengeance!", 1)]
        [DataRow(1009610, 20, 0, null, "Acts", null, "Acts of Vengeance!", 1)]
        [DataRow(1009610, 20, 0, null, null, "2013-06-30", null, 0)]
        public void ShouldReturnEvents(int idCharacter, int limit, int offSet, string title, string titleStartsWith, string modifiedSince, string resultTitle, int total)
        {
            var modifiedSinceDate = !string.IsNullOrEmpty(modifiedSince) ? DateTime.ParseExact(modifiedSince, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;

            var query = new GetEventsByIdCharacterQuery()
            {
                IdCharacter = idCharacter,
                Limit = limit,
                OffSet = offSet,
                Title = title,
                TitleStartsWith = titleStartsWith,
                ModifiedSince = modifiedSinceDate
            };

            var result = _repository.GetEventsByIdCharacterAsync(query).Result;

            Assert.AreEqual(result.Results.FirstOrDefault()?.Title, resultTitle);
            Assert.AreEqual(result.Total, total);
        }
    }
}
