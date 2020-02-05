using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelCharacters.Domain.Queries
{
    public class ComicQueryResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("issueNumber")]
        public double IssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("isbn")]
        public string ISBN { get; set; }

        [JsonProperty("upc")]
        public string UPC { get; set; }

        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }

        [JsonProperty("ean")]
        public string EAN { get; set; }

        [JsonProperty("issn")]
        public string ISSN { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("textObjects")]
        public IList<TextObjectQueryResult> TextObjects { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public IList<UrlQueryResult> Urls { get; set; }

        [JsonProperty("series")]
        public IList<SummaryQueryResult> Series { get; set; }

        //[JsonProperty("variants")]
        //public IList<ListSummaryQueryResult> Variants { get; set; }

        //[JsonProperty("collections")]
        //public IList<ListSummaryQueryResult> Collections { get; set; }

        //[JsonProperty("collectedIssues")]
        //public IList<ListSummaryQueryResult> CollectedIssues { get; set; }

        [JsonProperty("dates")]
        public IList<ComicDateQueryResult> Dates { get; set; }

        [JsonProperty("prices")]
        public IList<ComicPriceQueryResult> Prices { get; set; }

        [JsonProperty("thumbnail")]
        public ThumbnailQueryResult Thumbnail { get; set; }

        [JsonProperty("images")]
        public IList<ImageQueryResult> Images { get; set; }

        [JsonProperty("creators")]
        public ListQueryResult<CreatorSummaryQueryResult> Creators { get; set; }

        [JsonProperty("characters")]
        public ListQueryResult<SummaryQueryResult> Characters { get; set; }

        [JsonProperty("stories")]
        public ListQueryResult<SummaryQueryResult> Stories { get; set; }

        [JsonProperty("events")]
        public ListQueryResult<SummaryQueryResult> Events { get; set; }
    }
}
