using MarvelCharacters.Domain;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCharacters.Infra.Repositories
{
    public class StoriesRepository : IStoriesRepository
    {
        private readonly IMarvelCatalogContext _dbContext;

        public StoriesRepository(IMarvelCatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedQueryResult<StoryQueryResult>> GetStoriesByIdCharacterAsync(GetStoriesByIdCharacterQuery query)
        {
            var queryFiltered = _dbContext.Stories.AsNoTracking()
                .Where(w =>
                    w.Characters.Any(a => a.IdCharacter == query.IdCharacter) &&
                    (string.IsNullOrEmpty(query.Title) || w.Title == query.Title) &&
                    (string.IsNullOrEmpty(query.TitleStartsWith) || w.Title.StartsWith(query.TitleStartsWith)) &&
                    (query.ModifiedSince == null || w.Modified >= query.ModifiedSince)
                );

            var queryPaged = queryFiltered.Skip(query.OffSet).Take(query.Limit);

            return new PagedQueryResult<StoryQueryResult>
            {
                Count = queryPaged.Count(),
                Limit = query.Limit,
                OffSet = query.OffSet,
                Total = queryFiltered.Count(),
                Results = await queryPaged.Select(s => new StoryQueryResult
                {
                    Id = s.Id,
                    Description = s.Description,
                    Title = s.Title,
                    Modified = s.Modified,
                    ResourceURI = s.ResourceURI,
                    Type = s.Type
                }).ToListAsync()
            };
        }
    }
}
