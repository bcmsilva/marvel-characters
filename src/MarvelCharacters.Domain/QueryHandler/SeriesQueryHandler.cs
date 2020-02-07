using Flunt.Notifications;
using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.Queries.Outputs;
using MarvelCharacters.Domain.Queries.Results.Outputs;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Shared.Request;
using System.Threading.Tasks;

namespace MarvelCharacters.Domain.QueryHandler
{
    public class SeriesQueryHandler :
        Notifiable,
        IRequestHandler<GetSeriesByIdCharacterQuery, PagedQueryResult<SerieQueryResult>>
    {
        private readonly ISeriesRepository _repository;

        public SeriesQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IRequestResult<PagedQueryResult<SerieQueryResult>>> Handle(GetSeriesByIdCharacterQuery request)
        {
            if(!request.Validate())
            {
                AddNotifications(request);
                return new RequestResult<PagedQueryResult<SerieQueryResult>>(false, "It was not possible to get the Series");
            }

            return new RequestResult<PagedQueryResult<SerieQueryResult>>(true, "Series successfull returneds")
            {
                Data = await _repository.GetSeriesByIdCharacterAsync(request)
            };
        }
    }
}
