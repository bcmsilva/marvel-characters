using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelCharacters.Domain.Queries
{
    public class ComicDateQueryResult
    {
        [JsonProperty("Type")]
        public string type { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}
