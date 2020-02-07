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
    public class SeriesRepositoryTests
    {
        private FakeMarvelCatalogContext _dbContext;
        private SeriesRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new FakeMarvelCatalogContext();
            _dbContext.InitializeData();
            _repository = new SeriesRepository(_dbContext);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1009351, 20, 0, null, null, null, "Incredible Hulk (1962 - 1999)", 1)]
        [DataRow(1009351, 20, 0, "Incredible Hulk (1962 - 1999)", null, null, "Incredible Hulk (1962 - 1999)", 1)]
        [DataRow(1009610, 20, 0, null, "Peter Parker", null, "Peter Parker, the Spectacular Spider-Man (1976 - 1998)", 1)]
        [DataRow(1009610, 20, 0, null, null, "2018-01-22", "Peter Parker, the Spectacular Spider-Man (1976 - 1998)", 1)]
        [DataRow(1009351, 1, 0, null, null, null, "Incredible Hulk (1962 - 1999)", 1)]
        public void ShouldReturnSeries(int idCharacter, int limit, int offSet, string title, string titleStartsWith, string modifiedSince, string resultTitle, int total)
        {
            var modifiedSinceDate = !string.IsNullOrEmpty(modifiedSince) ? DateTime.ParseExact(modifiedSince, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;

            var query = new GetSeriesByIdCharacterQuery()
            {
                IdCharacter = idCharacter,
                Limit = limit,
                OffSet = offSet,
                Title = title,
                TitleStartsWith = titleStartsWith,
                ModifiedSince = modifiedSinceDate
            };

            var result = _repository.GetSeriesByIdCharacterAsync(query).Result;

            Assert.AreEqual(result.Results[0].Title, resultTitle);
            Assert.AreEqual(result.Total, total);
        }
    }
}
