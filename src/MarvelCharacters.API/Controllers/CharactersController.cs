using MarvelCharacters.Domain.Queries.Inputs;
using MarvelCharacters.Domain.QueryHandler;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarvelCharacters.API.Controllers
{
    public class CharactersController : Controller
    {
        private readonly CharactersQueryHandler _charactersQueryHandler;
        private readonly ComicsQueryHandler _comicsQueryHandler;
        private readonly EventsQueryHandler _eventsQueryHandler;
        private readonly SeriesQueryHandler _seriesQueryHandler;
        private readonly StoriesQueryHandler _storiesQueryHandler;

        public CharactersController(
            CharactersQueryHandler charactersQueryHandler,
            ComicsQueryHandler comicsQueryHandler,
            EventsQueryHandler eventsQueryHandler,
            SeriesQueryHandler seriesQueryHandler,
            StoriesQueryHandler storiesQueryHandler
            )
        {
            _charactersQueryHandler = charactersQueryHandler;
            _comicsQueryHandler = comicsQueryHandler;
            _eventsQueryHandler = eventsQueryHandler;
            _seriesQueryHandler = seriesQueryHandler;
            _storiesQueryHandler = storiesQueryHandler;
        }

        [HttpGet]
        [Route("v1/public/characters")]
        public async Task<IActionResult> GetCharactersAsync(GetCharactersQuery query)
        {
            var result = await _charactersQueryHandler.Handle(query);

            if (_charactersQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }

        [HttpGet]
        [Route("v1/public/characters/{IdCharacter}")]
        public async Task<IActionResult> GetCharacterAsync(GetOneCharacterQuery query)
        {
            var result = await _charactersQueryHandler.Handle(query);

            if (_charactersQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }

        [HttpGet]
        [Route("v1/public/characters/{IdCharacter}/comics")]
        public async Task<IActionResult> GeComicsAsync(GetComicsByIdCharacterQuery query)
        {
            var result = await _comicsQueryHandler.Handle(query);

            if (_comicsQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }

        [HttpGet]
        [Route("v1/public/characters/{IdCharacter}/events")]
        public async Task<IActionResult> GetEventsAsync(GetEventsByIdCharacterQuery query)
        {
            var result = await _eventsQueryHandler.Handle(query);

            if (_eventsQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }

        [HttpGet]
        [Route("v1/public/characters/{IdCharacter}/series")]
        public async Task<IActionResult> GetSeriesAsync(GetSeriesByIdCharacterQuery query)
        {
            var result = await _seriesQueryHandler.Handle(query);

            if (_seriesQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }

        [HttpGet]
        [Route("v1/public/characters/{IdCharacter}/stories")]
        public async Task<IActionResult> GetStoriesAsync(GetStoriesByIdCharacterQuery query)
        {
            var result = await _storiesQueryHandler.Handle(query);

            if (_storiesQueryHandler.Valid)
                return Ok(result);
            else
                return Conflict(result);
        }
    }
}
