using MarvelCharacters.Domain;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCharacters.Infra.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IMarvelCatalogContext _dbContext;

        public EventsRepository(IMarvelCatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedQueryResult<EventQueryResult>> GetEventsByIdCharacterAsync(GetEventsByIdCharacterQuery query)
        {
            var queryFiltered = _dbContext.Events.AsNoTracking()
                .Where(w =>
                    w.Characters.Any(a => a.IdCharacter == query.IdCharacter) &&
                    (string.IsNullOrEmpty(query.Title) || w.Title == query.Title) &&
                    (string.IsNullOrEmpty(query.TitleStartsWith) || w.Title.StartsWith(query.TitleStartsWith)) &&
                    (query.ModifiedSince == null || w.Modified >= query.ModifiedSince)
                );

            var queryPaged = queryFiltered.Skip(query.OffSet).Take(query.Limit);

            return new PagedQueryResult<EventQueryResult>
            {
                Count = queryPaged.Count(),
                Limit = query.Limit,
                OffSet = query.OffSet,
                Total = queryFiltered.Count(),
                Results = await queryPaged.Select(s => new EventQueryResult
                {
                    Id = s.Id,
                    Description = s.Description,
                    Title = s.Title,
                    Modified = s.Modified,
                    ResourceURI = s.ResourceURI,
                    End = s.End,
                    Start = s.Start
                }).ToListAsync()
            };
        }
    }
}
