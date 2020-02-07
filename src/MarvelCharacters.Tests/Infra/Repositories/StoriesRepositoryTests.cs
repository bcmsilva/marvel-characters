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
    public class StoriesRepositoryTests
    {
        private FakeMarvelCatalogContext _dbContext;
        private StoriesRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new FakeMarvelCatalogContext();
            _dbContext.InitializeData();
            _repository = new StoriesRepository(_dbContext);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1009351, 20, 0, null, null, null, "INCREDIBLE HULK (1999) #62", 1)]
        [DataRow(1009351, 20, 0, "INCREDIBLE HULK (1999) #62", null, null, "INCREDIBLE HULK (1999) #62", 1)]
        [DataRow(1009610, 20, 0, null, "Cover", null, "Cover #486", 1)]
        [DataRow(1009351, 20, 0, null, null, "2018-08-07", "INCREDIBLE HULK (1999) #62", 1)]
        [DataRow(1009351, 1, 0, null, null, null, "INCREDIBLE HULK (1999) #62", 1)]
        public void ShouldReturnStories(int idCharacter, int limit, int offSet, string title, string titleStartsWith, string modifiedSince, string resultTitle, int total)
        {
            var modifiedSinceDate = !string.IsNullOrEmpty(modifiedSince) ? DateTime.ParseExact(modifiedSince, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;

            var query = new GetStoriesByIdCharacterQuery()
            {
                IdCharacter = idCharacter,
                Limit = limit,
                OffSet = offSet,
                Title = title,
                TitleStartsWith = titleStartsWith,
                ModifiedSince = modifiedSinceDate
            };

            var result = _repository.GetStoriesByIdCharacterAsync(query).Result;

            Assert.AreEqual(result.Results[0].Title, resultTitle);
            Assert.AreEqual(result.Total, total);
        }
    }
}
