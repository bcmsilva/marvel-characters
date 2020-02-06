using MarvelCharacters.Domain.Entities.Links;
using System;
using System.Collections.Generic;

namespace MarvelCharacters.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Modified { get; set; }

        public string ResourceURI { get; set; }

        public IList<CharacterComicLink> Comics { get; set; }

        public IList<CharacterSerieLink> Series { get; set; }

        public IList<CharacterStoryLink> Stories { get; set; }

        public IList<CharacterEventLink> Events { get; set; }
    }
}
