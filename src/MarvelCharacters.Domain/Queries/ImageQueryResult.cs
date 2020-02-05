using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class ImageQueryResult
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
