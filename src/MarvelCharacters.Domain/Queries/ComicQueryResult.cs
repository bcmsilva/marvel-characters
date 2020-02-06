using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Queries
{
    public class ComicQueryResult
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

        [JsonProperty("series")]
        public IList<SummaryQueryResult> Series { get; set; }

        [JsonProperty("characters")]
        public ListQueryResult<SummaryQueryResult> Characters { get; set; }

        [JsonProperty("stories")]
        public ListQueryResult<StorySummaryQueryResult> Stories { get; set; }

        [JsonProperty("events")]
        public ListQueryResult<SummaryQueryResult> Events { get; set; }
    }
}
