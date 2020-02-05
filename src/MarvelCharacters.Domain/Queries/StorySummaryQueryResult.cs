using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class StorySummaryQueryResult : SummaryQueryResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
