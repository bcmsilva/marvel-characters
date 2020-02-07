using System;

namespace MarvelCharacters.Domain.Queries.Inputs
{
    public class GetCharactersQuery : GetPagedQuery
    {
        public string Name { get; set; }
        public string NameStartsWith { get; set; }
        public DateTime? ModifiedSince { get; set; }
    }
}
