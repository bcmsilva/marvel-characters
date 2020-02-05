using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelCharacters.Domain.Queries
{
    public class SummaryQueryResult
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
