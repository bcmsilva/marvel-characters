using Flunt.Notifications;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Shared.Request;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.QueryHandler
{
    public class EventsQueryHandler :
        Notifiable,
        IRequestHandler<GetEventsByIdCharacterQuery, PagedQueryResult<EventQueryResult>>
    {
        private readonly IEventsRepository _repository;

        public EventsQueryHandler(IEventsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IRequestResult<PagedQueryResult<EventQueryResult>>> Handle(GetEventsByIdCharacterQuery request)
        {
            if(!request.Validate())
            {
                AddNotifications(request);
                return new RequestResult<PagedQueryResult<EventQueryResult>>(false, "It was not possible to get the Events");
            }

            return new RequestResult<PagedQueryResult<EventQueryResult>>(true, "Events successfull returneds")
            {
                Data = await _repository.GetEventsByIdCharacterAsync(request)
            };
        }
    }
}
