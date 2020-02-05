using Newtonsoft.Json;
using System;

namespace MarvelCharacters.Domain.Queries
{
    public class EventQueryResult
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

        [JsonProperty("start")]
        public DateTime? Start { get; set; }

        [JsonProperty("end")]
        public DateTime? End { get; set; }

        [JsonProperty("comics")]
        public ListQueryResult<SummaryQueryResult> Comics { get; set; }

        [JsonProperty("series")]
        public ListQueryResult<SummaryQueryResult> Series { get; set; }

        [JsonProperty("stories")]
        public ListQueryResult<StorySummaryQueryResult> Stories { get; set; }

        [JsonProperty("characters")]
        public ListQueryResult<SummaryQueryResult> Characters { get; set; }

        [JsonProperty("next")]
        public SummaryQueryResult Next { get; set; }

        [JsonProperty("previous")]
        public SummaryQueryResult Previous { get; set; }
    }
}
