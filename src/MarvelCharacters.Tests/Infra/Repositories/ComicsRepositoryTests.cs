using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Infra.Repositories;
using MarvelCharacters.Tests.Infra.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace MarvelCharacters.Tests.Infra.Repositories
{
    [TestClass]
    public class ComicsRepositoryTests
    {
        private FakeMarvelCatalogContext _dbContext;
        private ComicsRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new FakeMarvelCatalogContext();
            _dbContext.InitializeData();
            _repository = new ComicsRepository(_dbContext);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1009351, 20, 0, null, null, null, "Hulk Custom Comic (2008) #1", 1)]
        [DataRow(1009351, 20, 0, "Hulk Custom Comic (2008) #1", null, null, "Hulk Custom Comic (2008) #1", 1)]
        [DataRow(1009610, 20, 0, null, "Marvel", null, "Marvel Age Spider-Man Vol. 2: Everyday Hero (Digest)", 1)]
        [DataRow(1009610, 20, 0, null, null, "2018-01-22", "Marvel Age Spider-Man Vol. 2: Everyday Hero (Digest)", 1)]
        [DataRow(1009351, 1, 0, null, null, null, "Hulk Custom Comic (2008) #1", 1)]
        public void ShouldReturnCharacters(int idCharacter, int limit, int offSet, string title, string titleStartsWith, string modifiedSince, string resultTitle, int total)
        {
            var modifiedSinceDate = !string.IsNullOrEmpty(modifiedSince) ? DateTime.ParseExact(modifiedSince, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;

            var query = new GetComicsByIdCharacterQuery()
            {
                IdCharacter = idCharacter,
                Limit = limit,
                OffSet = offSet,
                Title = title,
                TitleStartsWith = titleStartsWith,
                ModifiedSince = modifiedSinceDate
            };

            var result = _repository.GetComicsByIdCharacterAsync(query).Result;

            Assert.AreEqual(result.Results[0].Title, resultTitle);
            Assert.AreEqual(result.Total, total);
        }
    }
}
