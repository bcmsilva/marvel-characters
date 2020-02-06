using MarvelCharacters.Domain;
using MarvelCharacters.Domain.Queries;
using MarvelCharacters.Domain.Queries.Results;
using MarvelCharacters.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCharacters.Infra.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private MarvelCatalogContext _dbContext;

        public CharactersRepository(MarvelCatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedQueryResult<CharacterQueryResult>> GetCharactersAsync(GetPagedCharactersQuery query)
        {
            var queryFiltered = _dbContext.Characters.AsNoTracking()
                .Where(w =>
                    (string.IsNullOrEmpty(query.Name) || w.Name == query.Name) &&
                    (string.IsNullOrEmpty(query.NameStartsWith) || w.Name.StartsWith(query.NameStartsWith)) &&
                    (query.ModifiedSince == null || w.Modified >= query.ModifiedSince));

            var queryPaged = queryFiltered.Skip(query.OffSet).Take(query.Limit);

            return new PagedQueryResult<CharacterQueryResult>
            {
                Count = queryPaged.Count(),
                Limit = query.Limit,
                OffSet = query.OffSet,
                Total = queryFiltered.Count(),
                Results = await queryPaged.Select(s => new CharacterQueryResult
                {
                    Id = s.Id,
                    Description = s.Description,
                    Name = s.Name,
                    Modified = s.Modified,
                    ResourceURI = s.ResourceURI
                }).ToListAsync()
            };
        }
    }
}
