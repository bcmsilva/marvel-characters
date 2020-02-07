using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.Repositories
{
    public interface IComicsRepository
    {
        Task<PagedQueryResult<ComicQueryResult>> GetComicsByIdCharacterAsync(GetComicsByIdCharacterQuery request);
    }
}
