using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class ComicSummaryQueryResult : SummaryQueryResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
