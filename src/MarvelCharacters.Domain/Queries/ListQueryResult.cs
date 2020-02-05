using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Queries
{
    public class ListQueryResult<T> 
        where T : SummaryQueryResult
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<T> Items { get; set; }

        [JsonProperty("returned")]
        public string Returned { get; set; }
    }
}
