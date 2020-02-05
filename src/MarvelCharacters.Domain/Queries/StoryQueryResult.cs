using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Queries
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

        [JsonProperty("series")]
        public IList<SummaryQueryResult> Series { get; set; }

        [JsonProperty("characters")]
        public ListQueryResult<SummaryQueryResult> Characters { get; set; }

        [JsonProperty("comics")]
        public ListQueryResult<SummaryQueryResult> Comics { get; set; }

        [JsonProperty("events")]
        public ListQueryResult<SummaryQueryResult> Events { get; set; }

        [JsonProperty("originalissue")]
        public SummaryQueryResult Originalissue { get; set; }
    }
}
