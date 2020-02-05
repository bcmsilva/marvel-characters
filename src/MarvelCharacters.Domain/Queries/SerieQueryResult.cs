using Newtonsoft.Json;
using System;

namespace MarvelCharacters.Domain.Queries
{
    public class SerieQueryResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("startYear")]
        public int? StartYear { get; set; }

        [JsonProperty("endYear")]
        public int? EndYear { get; set; }

        [JsonProperty("comics")]
        public ListQueryResult<SummaryQueryResult> Comics { get; set; }

        [JsonProperty("characters")]
        public ListQueryResult<SummaryQueryResult> Characters { get; set; }

        [JsonProperty("stories")]
        public ListQueryResult<StorySummaryQueryResult> Stories { get; set; }

        [JsonProperty("events")]
        public ListQueryResult<SummaryQueryResult> Events { get; set; }

        [JsonProperty("next")]
        public SummaryQueryResult Next { get; set; }

        [JsonProperty("previous")]
        public SummaryQueryResult Previous { get; set; }
    }
}
