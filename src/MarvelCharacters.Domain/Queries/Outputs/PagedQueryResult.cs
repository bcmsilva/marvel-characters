using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Queries.Results.Outputs
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
