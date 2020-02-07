using Flunt.Notifications;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Shared.Request;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.QueryHandler
{
    public class ComicsQueryHandler :
        Notifiable,
        IRequestHandler<GetComicsByIdCharacterQuery, PagedQueryResult<ComicQueryResult>>
    {
        private readonly IComicsRepository _comicsRepository;

        public ComicsQueryHandler(IComicsRepository comicsRepository)
        {
            _comicsRepository = comicsRepository;
        }

        public async Task<IRequestResult<PagedQueryResult<ComicQueryResult>>> Handle(GetComicsByIdCharacterQuery request)
        {
            if(!request.Validate())
            {
                AddNotifications(request);
                return new RequestResult<PagedQueryResult<ComicQueryResult>>(false, "It was not possible to get the Comics");
            }

            return new RequestResult<PagedQueryResult<ComicQueryResult>>(true, "Comics successfull returneds")
            {
                Data = await _comicsRepository.GetComicsByIdCharacterAsync(request)
            };
        }
    }
}
