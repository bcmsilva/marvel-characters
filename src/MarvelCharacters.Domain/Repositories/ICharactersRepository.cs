using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.Repositories
{
    public interface ICharactersRepository
    {
        Task<PagedQueryResult<CharacterQueryResult>> GetCharactersAsync(GetPagedCharactersQuery query);
    }
}
