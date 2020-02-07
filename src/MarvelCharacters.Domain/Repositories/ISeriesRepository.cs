using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.Repositories
{
    public interface ISeriesRepository
    {
        Task<PagedQueryResult<SerieQueryResult>> GetSeriesByIdCharacterAsync(GetSeriesByIdCharacterQuery request);
    }
}
