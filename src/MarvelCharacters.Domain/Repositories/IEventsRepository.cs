using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.Repositories
{
    public interface IEventsRepository
    {
        Task<PagedQueryResult<EventQueryResult>> GetEventsByIdCharacterAsync(GetEventsByIdCharacterQuery request);
    }
}
