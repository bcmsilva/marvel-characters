using Flunt.Notifications;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Shared.Request;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.QueryHandler
{
    public class StoriesQueryHandler :
        Notifiable,
        IRequestHandler<GetStoriesByIdCharacterQuery, PagedQueryResult<StoryQueryResult>>
    {
        private readonly IStoriesRepository _repository;

        public StoriesQueryHandler(IStoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IRequestResult<PagedQueryResult<StoryQueryResult>>> Handle(GetStoriesByIdCharacterQuery request)
        {
            if(!request.Validate())
            {
                AddNotifications(request);
                return new RequestResult<PagedQueryResult<StoryQueryResult>>(false, "It was not possible to get the Stories");
            }

            return new RequestResult<PagedQueryResult<StoryQueryResult>>(true, "Stories successfull returneds")
            {
                Data = await _repository.GetStoriesByIdCharacterAsync(request)
            };
        }
    }
}
