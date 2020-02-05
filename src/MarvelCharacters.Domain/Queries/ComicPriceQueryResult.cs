using Newtonsoft.Json;

namespace MarvelCharacters.Domain.Queries
{
    public class ComicPriceQueryResult
    {
        [JsonProperty("Type")]
        public string Type { get; set; }
        
        [JsonProperty("Price")]
        public float? Price { get; set; }
    }
}
