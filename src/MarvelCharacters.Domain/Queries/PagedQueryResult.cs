using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelCharacters.Domain.Queries
{
    public class PagedQueryResult<T>
    {
        [JsonProperty("offset")]
        public int OffSet { get; set; }

        [JsonProperty("limit ")]
        public int Limit { get; set; }

        [JsonProperty("total ")]
        public int Total { get; set; }

        [JsonProperty("count ")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public IList<T> Results { get; set; }
    }
}
