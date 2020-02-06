using MarvelCharacters.Domain.Queries;
using MarvelCharacters.Infra.Repositories;
using MarvelCharacters.Infra.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarvelCharacters.Infra.Test.Repositories
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
        [DataRow(1, 0, null, null, null, "Hulk")]
        [DataRow(1, 1, null, null, null, "Spider-Man")]
        public void ShouldReturnCharactersPaged(int limit, int offSet, string name, string nameStartsWith, DateTime? modifiedSince, string resultName)
        {
            var query = new GetPagedCharactersQuery()
            { 
                Limit = limit,
                OffSet = offSet,
                Name = name,
                NameStartsWith = nameStartsWith,
                ModifiedSince = modifiedSince
            };

            var result = _charactersRepository.GetCharactersAsync(query).Result;

            Assert.AreEqual(result.Results[0].Name, resultName);
        }
    }
}
