using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class UrlQueryResult
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
