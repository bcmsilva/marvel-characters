using System.Threading.Tasks;

namespace MarvelCharacters.Shared.Request
{
    public interface IRequestHandler<T, TResult> where T : IRequest
    {
        Task<IRequestResult<TResult>> Handle(T request);
    }
}
