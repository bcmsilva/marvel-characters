using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelCharacters.Domain.Queries
{
    public class TextObjectQueryResult
    {
        [JsonProperty("type")]
        public string Type {get;set;}
        
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
