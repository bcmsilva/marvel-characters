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
    public class CharactersRepositoryTests
    {
        private FakeMarvelCatalogContext _dbContext;
        private CharactersRepository _charactersRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new FakeMarvelCatalogContext();
            _dbContext.InitializeData();
            _charactersRepository = new CharactersRepository(_dbContext);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(20, 0, null, null, null, "Hulk", 2)]
        [DataRow(20, 0, "Hulk", null, null, "Hulk", 1)]
        [DataRow(20, 0, null, "Spi", null, "Spider-Man", 1)]
        [DataRow(20, 0, null, null, "2019-02-06", "Spider-Man", 1)]
        [DataRow(1, 0, null, null, null, "Hulk", 2)]
        [DataRow(1, 1, null, null, null, "Spider-Man", 2)]
        public void ShouldReturnCharacters(int limit, int offSet, string name, string nameStartsWith, string modifiedSince, string resultName, int total)
        {
            var modifiedSinceDate = !string.IsNullOrEmpty(modifiedSince) ? DateTime.ParseExact(modifiedSince, "yyyy-MM-dd", CultureInfo.InvariantCulture) : (DateTime?)null;

            var query = new GetCharactersQuery()
            {
                Limit = limit,
                OffSet = offSet,
                Name = name,
                NameStartsWith = nameStartsWith,
                ModifiedSince = modifiedSinceDate
            };

            var result = _charactersRepository.GetCharactersAsync(query).Result;

            Assert.AreEqual(result.Results[0].Name, resultName);
            Assert.AreEqual(result.Total, total);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(1009351, "Hulk", 1)]
        [DataRow(1009610, "Spider-Man", 1)]
        [DataRow(123, null, 0)]
        public void ShouldReturnOneCharacter(int idCharacter, string resultName, int total)
        {
            var query = new GetOneCharacterQuery()
            {
                IdCharacter = idCharacter
            };

            var result = _charactersRepository.GetOneCharacterAsync(query).Result;

            Assert.AreEqual(result.Results.FirstOrDefault()?.Name, resultName);
            Assert.AreEqual(result.Total, total);
        }
    }
}
