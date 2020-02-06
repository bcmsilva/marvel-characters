using MarvelCharacters.Domain.Queries;
using MarvelCharacters.Domain.Queries.Results;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.Repositories
{
    public interface ICharactersRepository
    {
        Task<PagedQueryResult<CharacterQueryResult>> GetCharactersAsync(GetPagedCharactersQuery query);
    }
}
