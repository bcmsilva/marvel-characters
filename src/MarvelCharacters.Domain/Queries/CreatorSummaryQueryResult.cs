using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class CreatorSummaryQueryResult : SummaryQueryResult
    {
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
