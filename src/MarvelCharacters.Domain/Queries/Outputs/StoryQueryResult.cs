using Newtonsoft.Json;
using System;

namespace MarvelCharacters.Domain.Queries.Results.Outputs
{
    public class StoryQueryResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
