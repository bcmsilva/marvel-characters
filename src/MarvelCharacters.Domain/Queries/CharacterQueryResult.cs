using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Queries
{
    public class CharacterQueryResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("thumbnail")]
        public ThumbnailQueryResult Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("comics")]
        public ListQueryResult<ComicSummaryQueryResult> Comics { get; set; }

        [JsonProperty("series")]
        public ListQueryResult<SummaryQueryResult> Series { get; set; }

        [JsonProperty("stories")]
        public ListQueryResult<SummaryQueryResult> Stories { get; set; }

        [JsonProperty("events")]
        public ListQueryResult<SummaryQueryResult> Events { get; set; }

        [JsonProperty("urls")]
        public IList<UrlQueryResult> Urls { get; set; }
    }
}
