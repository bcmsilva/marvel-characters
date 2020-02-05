using MarvelCharacters.Domain.Entities.Links;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Comic
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public IList<Serie> Series { get; set; }

        public IList<CharacterComicLink> Characters { get; set; }

        public IList<Story> Stories { get; set; }

        public IList<Event> Events { get; set; }
    }
}